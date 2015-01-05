using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform objectToFollow;

	public float cameraSpeed;

	public float mapX;
	public float mapY;
	
	private float minX;
	private float maxX;
	private float minY;
	private float maxY;

	public void Start() {
		float vertExtent = Camera.main.camera.orthographicSize;    
		float horzExtent = vertExtent * Screen.width / Screen.height;
		
		// Calculations assume map is position at the origin
		minX = horzExtent - mapX / 2.0f;
		maxX = mapX / 2.0f - horzExtent;
		minY = vertExtent - mapY / 2.0f;
		maxY = mapY / 2.0f - vertExtent;
	}
	
	// Update is called once per frame
	private Vector3 tempTargetPos;
	void Update () {
		tempTargetPos = new Vector3 (objectToFollow.position.x, objectToFollow.position.y, transform.position.z);
		transform.Translate ((tempTargetPos - transform.position) * Time.deltaTime * cameraSpeed);
	}

	public void LateUpdate() {
		Vector3 v3 = transform.position;
		v3.x = Mathf.Clamp(v3.x, minX, maxX);
		v3.y = Mathf.Clamp(v3.y, minY, maxY);
		transform.position = v3;
	}
}
