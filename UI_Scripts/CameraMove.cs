using UnityEngine;
using System.Collections;
using DG.Tweening;
public class CameraMove : MonoBehaviour {
    [SerializeField]
    Transform cameras;
    [SerializeField]
     Vector3 targetPosition,targetRotation;
	// Use this for initialization
	void Start () {
        MoveCamera(targetPosition, targetRotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void MoveCamera(Vector3 targetPos, Vector3 targetRot)
    {
        cameras.DOMove(targetPos, 2, false);
        cameras.DORotate(targetRot, 2);
    }
}
