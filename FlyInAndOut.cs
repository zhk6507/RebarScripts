using UnityEngine;
using System.Collections;
using DG.Tweening;
public class FlyInAndOut : MonoBehaviour {
    private Transform thispanel;

    public Vector2 stayposition;
    public Vector2 initposition;
    public Vector2 targetpostion;
	void Start () {
        thispanel=GetComponent<Transform>();
        initposition = thispanel.localPosition;
        thispanel.localPosition = stayposition;
	}
	
	public void FlyIn()
    {
        thispanel.DOLocalMove(initposition, 0.5f, false);
    }
    public void FlyOut()
    {
        thispanel.DOLocalMove(targetpostion, 0.5f, false);
    }
}
