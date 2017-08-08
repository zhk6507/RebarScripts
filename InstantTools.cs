using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstantTools : MonoBehaviour {
    [SerializeField]
    GameObject tool;
   
   public bool isFollow = false;
    [SerializeField]
    RectTransform ui_canvas;
    [SerializeField]
    Camera ui_Camera;
    public string currentToolName;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            tool.SetActive(false);
        }
	}
    /// <summary>
    /// 实例化工具
    /// </summary>
    /// <param name="toolname"></param>
    public void InstantTool(string toolname)
    {
        tool.SetActive(true);
        Sprite sp = Resources.Load<Sprite>(toolname);
        tool.GetComponentInChildren<Image>().sprite = sp;
        isFollow = true;
        StartCoroutine(ToolFollowMouseMove());
    }
    /// <summary>
    /// 图片跟随鼠标移动
    /// </summary>
    /// <returns></returns>
    IEnumerator ToolFollowMouseMove()
    {
        while (isFollow)
        {
            Vector2 temppos = new Vector2();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(ui_canvas, Input.mousePosition, ui_Camera, out temppos);
            tool.GetComponent<RectTransform>().anchoredPosition = temppos;
            yield return null;
        }
    }
}
