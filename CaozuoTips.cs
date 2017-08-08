using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaozuoTips : MonoBehaviour {
    private static CaozuoTips instance;

    public static CaozuoTips Instance
    {
        get { return CaozuoTips.instance; }
    }
    private CaozuoTips() { }
    private Text tipsContent;
    void Awake()
    {
        instance = this;
    }
	void Start ()
    {
        tipsContent = GetComponentInChildren<Text>();
    }
    public void UpdateTipsTxt(string content)
    {
        tipsContent.text = content;
    }
}
