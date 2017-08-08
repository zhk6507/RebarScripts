using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ControllStep : MonoBehaviour
{
    [SerializeField]
    Toggle zhantie;
    [SerializeField]
    private List<string> toolName;
    public bool startZhantie = false;
    [SerializeField]
    Transform toolIame;
    [SerializeField]
    GameObject toolBox;

    Vector3 toolPosition;
    private int step = 0;
    // Use this for initialization
    void Start()
    {
        toolPosition = toolIame.position;
    }
    /// <summary>
    /// 初始化
    /// </summary>
    public void initState()
    {
        Debug.Log("初始化");
    }

    /// <summary>
    /// 应变片黏贴
    /// </summary>
    /// <returns></returns>
    public IEnumerator ZhanTie()
    {
        while (startZhantie)
        {
            string current = GetComponent<InstantTools>().currentToolName;
            if (current == toolName[step])
            {
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //RaycastHit hit;
                //if (Physics.Raycast(ray, out hit))
                //{
                    CaozuoTips.Instance.UpdateTipsTxt("继续黏贴应变片操作");
                if (Input.GetMouseButtonDown(0))
                {
                    PlayAnimation();
                    toolIame.gameObject.SetActive(false);
                    step++;
                    break;
                }

                //}
                //step++;
            }
            else
            {
                CaozuoTips.Instance.UpdateTipsTxt("顺序错误");
            }
            yield return null;
        }
    }
    [SerializeField]
    Animator anim;
    AnimatorStateInfo animInfo;

    void PlayAnimation()
    {
        if (step < toolName.Count-1)
        {
            anim.SetTrigger("PlayNext");
        }
    }
    public void PlayHunningtu()
    {
        anim.SetBool("PlayHunningtu", true);
    }
}
