using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShiJianShejiPanelManager : MonoBehaviour
{
    #region
    [SerializeField]
    private Toggle toggle1;
    [SerializeField]
    private Toggle toggle2;
    [SerializeField]
    private Toggle toggle3;
    [SerializeField]
    private Toggle toggle4;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    public GameObject tipsView1;
    public GameObject tipsView2;
    public GameObject tipsView3;
    public GameObject tipsView4;

    public GameObject mainCameras;
    public Image shijin, shaojin, chaojin;
    public GameObject loadPanel;
    public Text shiyanmingcheng;
    #endregion
    // Use this for initialization
	void Start ()
    {
        #region UI监听
        toggle1.onValueChanged.AddListener(delegate(bool isOn)
        {
            InitState();
            panel1.SetActive(isOn);
        }); 
        toggle2.onValueChanged.AddListener(delegate(bool isOn)
        {
            InitState();
            panel2.SetActive(isOn);
        });
        toggle3.onValueChanged.AddListener(delegate(bool isOn)
        {
            InitState();
            panel3.SetActive(isOn);
        });
        toggle4.onValueChanged.AddListener(delegate(bool isOn)
        {
            InitState();
            panel4.SetActive(isOn);
        }); 
#endregion
    }
    void OnDisable()
    {
        mainCameras.GetComponent<PlayerRoam>().enabled = true;
        SetResult();
    }

    private void SetResult()
    {
        shijin.gameObject.SetActive(false);
        shaojin.gameObject.SetActive(false);
        chaojin.gameObject.SetActive(false);
        if (GetComponent<JudgeData>().zj_distance==100)
        {
            shijin.fillAmount = 0;
            shijin.gameObject.SetActive(true);
            loadPanel.GetComponent<LoadAddForce>().setCurve(shijin);
            loadPanel.GetComponent<LoadAddForce>().SetMovie("适筋");
            shiyanmingcheng.text = "钢筋混凝土正截面纯弯适筋实验";
        }
        else if (GetComponent<JudgeData>().zj_distance > 100)
        {
            shaojin.fillAmount = 0;
            shaojin.gameObject.SetActive(true);
            loadPanel.GetComponent<LoadAddForce>().setCurve(shaojin);
            loadPanel.GetComponent<LoadAddForce>().SetMovie("少筋");
            shiyanmingcheng.text = "钢筋混凝土正截面纯弯少筋实验";
        }
        else
        {
            chaojin.fillAmount = 0;
            chaojin.gameObject.SetActive(true);
            loadPanel.GetComponent<LoadAddForce>().setCurve(chaojin);
            loadPanel.GetComponent<LoadAddForce>().SetMovie("超筋");
            shiyanmingcheng.text = "钢筋混凝土正截面纯弯超筋实验";
        }
    }
    /// <summary>
    /// 初始化
    /// </summary>
    void InitState()
    {
        tipsView1.SetActive(false);
        tipsView2.SetActive(false);
        tipsView3.SetActive(false);
        tipsView4.SetActive(false);
    }
}
