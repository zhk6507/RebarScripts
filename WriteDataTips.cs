using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WriteDataTips : MonoBehaviour {

    private static WriteDataTips instance;

    public static WriteDataTips Instance
    {
        get { return WriteDataTips.instance; }
    }
    private WriteDataTips() { }

    private Text tipsText;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        tipsText = GetComponentInChildren<Text>();
    }
    
    public void UpdateTipsText(string content)
    {
        tipsText.text = content;
    }
}
