using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float playerMoveSpeed;
	public float playerRotateSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Move player when input axis are modified from -1 to +1
		//to achieve an smooth movement

		transform.Translate (	Input.GetAxis ("Horizontal") * playerMoveSpeed * Time.deltaTime,
		                    	Input.GetAxis ("Vertical") * playerMoveSpeed * Time.deltaTime,
		                    	0.0f,
		                     	Space.World);

		//Rotate the player to aim using mouse position
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
	}
}
