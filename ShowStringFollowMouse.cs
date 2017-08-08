using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowStringFollowMouse : MonoBehaviour
{
    public GameObject nameView;
   //public Toggle shixiansheji;
    public RectTransform ui_canvas;
    public Camera ui_Camera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (!shixiansheji.isOn)
        //{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag != " ")
                {
                    nameView.GetComponentInChildren<Text>().text = hit.collider.tag;
                    Vector2 temppos = new Vector2();
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(ui_canvas, Input.mousePosition, ui_Camera, out temppos);
                    nameView.GetComponent<RectTransform>().anchoredPosition = temppos;

                }
                else 
                {
                    nameView.GetComponent<RectTransform>().anchoredPosition = new Vector2(1000, 0);
                }
            }
            else
            {
                nameView.GetComponent<RectTransform>().anchoredPosition = new Vector2(1000, 0);
            }
        //}
    }
}