using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Panel2Manager : MonoBehaviour {
    [SerializeField]
    private Dropdown dropDown;
    [SerializeField]
    private GameObject inputFiled;
	// Use this for initialization
	void Start () {
        dropDown.onValueChanged.AddListener(delegate(int value)
        {
            SelectHunNingtu(value);
        });
	}

    private void SelectHunNingtu(int value)
    {
        if (value == 3)
        {
            inputFiled.SetActive(true);
        }
        else
        {
            inputFiled.SetActive(false);            
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
