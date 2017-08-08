using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 点击左右按钮切换图片
/// </summary>
public class ChangeImageByBtn : MonoBehaviour {
    [SerializeField]
    Button leftBtn;
    [SerializeField]
    Button rightBtn;
    [SerializeField]
    Image tipsImage;
    [SerializeField]
    Sprite[] targetImage;
	// Use this for initialization
	void Start () {
        int i = 0;
        leftBtn.onClick.AddListener(delegate
        {
            i--;
            if (i >= 0)
            {
                tipsImage.sprite = targetImage[i];
            }
            else
            {
                i = targetImage.Length - 1;
                tipsImage.sprite = targetImage[i];
            }
        });
        rightBtn.onClick.AddListener(delegate
        {
            i++;
            if (i > targetImage.Length-1)
            {
                i = 0;
                tipsImage.sprite = targetImage[i];
            }
            else
            {
                tipsImage.sprite = targetImage[i];                
            }
        });
	}
}
