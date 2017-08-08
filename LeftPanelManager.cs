using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeftPanelManager : MonoBehaviour {

    [SerializeField]
    Toggle tog1, tog2, tog3, tog4;
    [SerializeField]
    GameObject shijianPanel, rightPanel, loadPanel, shiyanbaogao, movieImage, resetBtn,nameString,mianCamera;
	void Start () {
	    tog1.onValueChanged.AddListener(delegate(bool isOn)
        {
            shijianPanel.SetActive(isOn);
            mianCamera.GetComponent<PlayerRoam>().enabled = false;
            mianCamera.GetComponent<CameraTargeting>().enabled = false;
            nameString.GetComponent<ShowStringFollowMouse>().enabled = false;
        });
        
	}

    public void OtherToggle()
    {
        tog2.onValueChanged.AddListener(delegate(bool isOn)
        {
            if (isOn)
            {
                rightPanel.GetComponent<FlyInAndOut>().FlyIn();
                Camera.main.GetComponent<Transform>().position = new Vector3(-90.89f, 20.18f, 18.11f);
                Quaternion rot = Quaternion.Euler(new Vector3(11.3f, -180.2f, 0));
                Camera.main.GetComponent<Transform>().rotation = rot;

            }
            else
            {
                rightPanel.GetComponent<FlyInAndOut>().FlyOut();
            }
            rightPanel.GetComponent<ControllStep>().startZhantie = isOn;
            mianCamera.GetComponent<PlayerRoam>().enabled = !isOn;
        });
        tog3.onValueChanged.AddListener(delegate(bool isOn)
        {
            if (isOn)
            {
                Camera.main.GetComponent<Transform>().position = new Vector3(-92.03f, 21.45f, 26.02f);
                Quaternion rot = Quaternion.Euler(new Vector3(9.19f, -179.69f, 0));
                Camera.main.GetComponent<Transform>().rotation = rot;
            }
            mianCamera.GetComponent<PlayerRoam>().enabled = !isOn;
            movieImage.SetActive(isOn);
            resetBtn.SetActive(isOn);
            if (loadPanel.activeSelf)
            {
                loadPanel.GetComponentInChildren<LoadAddForce>().ResetEvent();

            }
            StartCoroutine(loadPanel.GetComponentInChildren<LoadAddForce>().ResetMovie());
            loadPanel.SetActive(isOn);

        });
        tog4.onValueChanged.AddListener(delegate(bool isOn)
        {
            mianCamera.GetComponent<PlayerRoam>().enabled = !isOn;
            shiyanbaogao.SetActive(isOn);
        });
    }
}
