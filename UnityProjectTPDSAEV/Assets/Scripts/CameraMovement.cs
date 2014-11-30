using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform objectToFollow;

	public float cameraSpeed;
	
	// Update is called once per frame
	private Vector3 tempTargetPos;
	void Update () {
		tempTargetPos = new Vector3 (objectToFollow.position.x, objectToFollow.position.y, transform.position.z);
		transform.Translate ((tempTargetPos - transform.position) * Time.deltaTime * cameraSpeed);
	}
}
