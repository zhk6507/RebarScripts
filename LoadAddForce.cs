using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LoadAddForce : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public MovieTexture movie;
    public RectTransform zhizhenImage;
    public RectTransform zhizhenIamge2;
    public Button resetBtn;
    [SerializeField]
    Vector3 zhizhenRot;
    [SerializeField]
    Quaternion initQuaternion1, initQuaternion2;
    [SerializeField]
    Image curve;//函数曲线
    public RawImage movieimage;
    private bool down = false;
    
    void Start()
    {

        initQuaternion1 = zhizhenImage.localRotation;
        initQuaternion2 = zhizhenIamge2.localRotation;
        movieimage.texture = movie;
        movie.loop = false;
        //充值按钮点击事件
        resetBtn.onClick.AddListener(delegate
        {
            ResetEvent();
            StartCoroutine(ResetMovie());
            
        });
    }

    
    void Update()
    {
        if (down && movie.isPlaying)
        {
            zhizhenImage.Rotate(-zhizhenRot, Space.Self);
            zhizhenIamge2.Rotate(-zhizhenRot, Space.Self);
            //curve.fillAmount += (1 / 5)*Time.deltaTime;
            curve.fillAmount += 0.0075f;
        }
    }
    /// <summary>
    /// 设置当前播放曲线
    /// </summary>
    /// <param name="xian"></param>
    public void setCurve(Image xian)
    {
        curve = xian;
    }
    /// <summary>
    /// 设置当前播放视频
    /// </summary>
    /// <param name="movieName"></param>
    public void SetMovie(string movieName)
    {
        movie = Resources.Load<MovieTexture>(movieName);
        movieimage.texture = movie;
        movie.loop = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        movie.Play();
        down = true;
        //zhizhenImage.localEulerAngles = zhizhenRot;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        movie.Pause();
        down = false;
    }
    /// <summary>
    /// 重置事件
    /// </summary>
    public void ResetEvent()
    {
        zhizhenImage.rotation = initQuaternion1;
        zhizhenIamge2.rotation = initQuaternion2;
        curve.fillAmount = 0;
    }
    /// <summary>
    /// 重置movie
    /// </summary>
    /// <returns></returns>
    public IEnumerator ResetMovie()
    {

        yield return null;
        movie.Stop();
        yield return null;
        movie.Play();
        yield return null;
        movie.Pause();
    }
}
