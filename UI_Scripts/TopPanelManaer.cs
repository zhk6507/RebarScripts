using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TopPanelManaer : MonoBehaviour {

    [SerializeField]
    Toggle shiyanJieshao,shiyanMudi;
    [SerializeField]
    GameObject jieshaoImage, MudiImage;

	void Start () {
        shiyanJieshao.onValueChanged.AddListener(delegate(bool isOn)
        {
            if (isOn)
            {
                jieshaoImage.GetComponent<FlyInAndOut>().FlyIn();
            }
            else
            {
                jieshaoImage.GetComponent<FlyInAndOut>().FlyOut();
            }
        });
        shiyanMudi.onValueChanged.AddListener(delegate(bool isOn)
        {
            if (isOn)
            {
                MudiImage.GetComponent<FlyInAndOut>().FlyIn();
            }
            else
            {
                MudiImage.GetComponent<FlyInAndOut>().FlyOut();
            }
        });
	}
}
