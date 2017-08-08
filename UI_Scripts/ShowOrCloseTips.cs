using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowOrCloseTips : MonoBehaviour {
    [SerializeField]
    GameObject tipsView;
	void Start () {
        GetComponent<Toggle>().onValueChanged.AddListener(delegate(bool isOn)
        {
            tipsView.SetActive(isOn);
        });
	}
}
