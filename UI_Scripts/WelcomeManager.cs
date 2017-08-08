using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WelcomeManager : MonoBehaviour {

    public void OnclickExit()
    {
        Application.Quit();
    }
    public void LoadScenesByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
	
}
