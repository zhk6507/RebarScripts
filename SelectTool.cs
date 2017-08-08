using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class SelectTool : MonoBehaviour
{
    private GameObject rightpanel;
    [SerializeField]
    Transform weiyiji;
    void Start()
    {
        rightpanel = GameObject.Find("RightPanel");
        weiyiji = GameObject.Find("gjl-zb-jx-630").transform;
        GetComponent<Button>().onClick.AddListener(delegate
        {
            if (this.gameObject.name != "混凝土" && this.gameObject.name != "位移计")
            {
                rightpanel.GetComponent<InstantTools>().currentToolName = this.gameObject.name;
                rightpanel.GetComponent<InstantTools>().InstantTool(this.gameObject.name);
                StartCoroutine(rightpanel.GetComponent<ControllStep>().ZhanTie());

            }
            else if (this.gameObject.name == "混凝土")
            {
                rightpanel.GetComponent<InstantTools>().currentToolName = this.gameObject.name;
                //StartCoroutine(rightpanel.GetComponent<ControllStep>().ZhanTie());
                rightpanel.GetComponent<ControllStep>().PlayHunningtu();
            }
            else if (this.gameObject.name != "位移计")
            {
                weiyiji.DOScale(1.0f, 0.5f);
            }
        });
    }

}
