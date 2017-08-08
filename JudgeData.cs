using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
/// <summary>
/// 试件设计 判断输入数据
/// </summary>
public class JudgeData : MonoBehaviour
{
    #region 声明UI
    [SerializeField]
    Button finish;//确定按钮
    [SerializeField]
    InputField jiemianWide;//截面宽度b
    [SerializeField]
    InputField jiemianHight;//截面高度h
    [SerializeField]
    Dropdown hunningtuIntensity;//混凝土强度dropDown
    [SerializeField]
    InputField intensityInput;//混凝土强度inputfield
    [SerializeField]
    InputField zongjinDiameter;//纵筋直径
    [SerializeField]
    InputField zongjinDistance;//纵筋间距
    [SerializeField]
    Dropdown zongjinGrade;//纵筋等级dropDown
    [SerializeField]
    InputField gradeInput;//纵筋等级inputfield
    [SerializeField]
    InputField gujinDiameter;//箍筋直径
    [SerializeField]
    InputField gujinDistance;//箍筋间距
    #endregion
    [SerializeField]
    GameObject leftPanel;

    public string str_wide="";//宽度
    public string str_hight="";//高度
    public string intensity="C30";//强度
    public string str_zj_diameter="";//纵筋直径
    public string str_zj_distance="";//纵筋间距
    public string grade = "HRB335";//等级
    public string str_gj_diameter = "";//箍筋直径
    public string str_gj_distance = "";//箍筋间距

    [SerializeField]
    public int wide = 0, hight = 0, zj_diameter = 0, zj_distance=0,
                gj_diameter = 10, gj_distance=0;
    [SerializeField]
    private GameObject writeDataTipsView;

    private string intensityStr = "C15C20C25C30C35C40C45C50C55C60C65C70C75C80";
    private string gradeStr = "HPB300HRB335HRBF335HRB400HRBF400RRB400HRB500HRBF500";
	void Start ()
    {
        #region UI监听
        //截面宽度输入框
        jiemianWide.onEndEdit.AddListener(delegate(string content)
        {
            str_wide = content;
        });
        //截面高度输入框
        jiemianHight.onEndEdit.AddListener(delegate(string content)
        {
            str_hight = content;
        });
        //混凝土强度dropDown
        hunningtuIntensity.onValueChanged.AddListener(delegate(int value)
        {
            intensity = hunningtuIntensity.captionText.text;
        });
        //混凝土强度inputfield
        intensityInput.onEndEdit.AddListener(delegate(string content)
        {
            intensity = content;
        });
        //纵筋直径输入框
        zongjinDiameter.onEndEdit.AddListener(delegate(string content)
        {
            str_zj_diameter = content;
        });
        //纵筋间距输入框
        zongjinDistance.onEndEdit.AddListener(delegate(string content)
        {
            str_zj_distance = content;
        });
        //纵筋等级dropDown
        zongjinGrade.onValueChanged.AddListener(delegate(int value)
        {
            grade = zongjinGrade.captionText.text;
        });
        //纵筋等级inputfield
        gradeInput.onEndEdit.AddListener(delegate(string content)
        {
            grade = content;
        });
        //箍筋直径
        gujinDiameter.onEndEdit.AddListener(delegate(string content)
        {
            str_gj_diameter = content;
        });
        //箍筋间距
        gujinDistance.onEndEdit.AddListener(delegate(string content)
        {
            str_gj_distance = content;
        });
        #endregion
        finish.onClick.AddListener(delegate
        {
            
            wide = StringToNumber(str_wide);
            hight = StringToNumber(str_hight);
            zj_diameter = StringToNumber(str_zj_diameter);
            zj_distance = StringToNumber(str_zj_distance);
            //gj_diameter = StringToNumber(str_gj_diameter);
            gj_distance = StringToNumber(str_gj_distance);
            JudgeDataAndTips();
        });
    }
    /// <summary>
    /// 判断输入的数据并提示
    /// </summary>
    bool isNull = true;
    private void JudgeDataAndTips()
    {
        if (isNull)
        {
            if (str_wide == "" || str_hight == "")
            {
                WriteDataTips.Instance.UpdateTipsText("截面尺寸界面有数据未填写，请填写完整！");
            }
            else if (intensity == "" || intensity == "其他" || !intensityStr.Contains(intensity))
            {
                WriteDataTips.Instance.UpdateTipsText("混凝土参数界面输入数据不正确或未注意大小写，请修改！");
            }
            else if (str_zj_diameter == "" || str_zj_distance == "" || grade == "其他" || grade == "")
            {
                WriteDataTips.Instance.UpdateTipsText("纵向钢筋界面有数据未填写，请填写完整");
            }
            else if (!gradeStr.Contains(grade))
            {
                WriteDataTips.Instance.UpdateTipsText("纵向钢筋界面输入数据不正确或未注意大小写，请修改！");
            }
            else if (str_gj_distance == "")
            {
                WriteDataTips.Instance.UpdateTipsText("箍筋界面有数据未填写，请填写完整");
                
            }
            else
            {
                isNull = false;
            }
        }
        else
        {
            if (wide < 120 || wide > 350)
            {
                WriteDataTips.Instance.UpdateTipsText("实验梁截面宽度不在常用范围内，请修改！");
            }
            else if (hight < 250 || hight > 1000)
            {
                WriteDataTips.Instance.UpdateTipsText("实验梁截面高度不在常用范围内，请修改！");
            }
            else if ((hight > 300 && zj_diameter < 10) || (hight < 300 && zj_diameter < 8))
            {
                WriteDataTips.Instance.UpdateTipsText("纵筋直径小于该截面高度下允许的钢筋直径最小值，请修改！");
            }
            else if (zj_diameter < 10 || zj_diameter > 28)
            {
                WriteDataTips.Instance.UpdateTipsText("纵筋直径数值不在常用范围内！");
            }
            else if (zj_distance < 25)
            {
                WriteDataTips.Instance.UpdateTipsText("纵筋间距不应小于25mm！");
            }
            else if (gj_distance > MinInThis(wide, hight) || gj_distance>400)
            {
                WriteDataTips.Instance.UpdateTipsText("箍筋间距不应大于截面短边尺寸，且不大于400mm！");               
            }
            else
            {
                WriteDataTips.Instance.UpdateTipsText("试件设计完成，进入后续操作");
                Invoke("FlyOut", 1);
                CaozuoTips.Instance.UpdateTipsTxt("选择左侧菜单完成操作");
                leftPanel.GetComponent<LeftPanelManager>().OtherToggle();
            }
        }
        writeDataTipsView.GetComponent<FlyInAndOut>().FlyIn();
    }
    private void FlyOut()
    {
        writeDataTipsView.GetComponent<FlyInAndOut>().FlyOut();
        this.gameObject.SetActive(false);
    }

    
    /// <summary>
    /// 字符串转int
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public int StringToNumber(string str)
    {
        int target=0;
        try
        {
            target = Convert.ToInt32(str);
        }
        catch (System.Exception)
        {

            Debug.Log("请正确输入");
        }

        return target;
    }
    /// <summary>
    /// 取两个数中的最小值
    /// </summary>
    /// <param name="n1"></param>
    /// <param name="n2"></param>
    /// <returns></returns>
    public int MinInThis(int n1, int n2)
    {
        int min=0;
        min = n1 < n2 ? n1 : n2;
        return min;
    }

    //enum 
}
