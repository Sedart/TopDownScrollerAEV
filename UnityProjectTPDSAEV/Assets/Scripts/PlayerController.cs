using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Player player;

	public float playerMoveSpeed;
	public float playerRotateSpeed;

	private Transform bulletSpawnPos;

	// Use this for initialization
	void Start () {
		bulletSpawnPos = GameObject.Find ("Hero/MainWeapon/BulletSpawnPos").transform;
		Debug.Log (bulletSpawnPos);
	}
	
	// Update is called once per frame
	void Update () {
		#region movement and aim
		//Move player when input axis are modified from -1 to +1
		//to achieve an smooth movement

		transform.Translate (	Input.GetAxis ("Horizontal") * playerMoveSpeed * Time.deltaTime,
		                    	Input.GetAxis ("Vertical") * playerMoveSpeed * Time.deltaTime,
		                    	0.0f,
		                     	Space.World);

		//Rotate the player to aim using mouse position
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
		#endregion

		#region weapon shoot
		//Shoot player main weapon when left click is pressed
		if(Input.GetKey(KeyCode.Mouse0))
		{
			if(player.mainWeapon.CanShoot()){
				player.mainWeapon.Shoot(bulletSpawnPos.position, player.gameObject.transform.rotation);
			}
		}
		#endregion
	}
}
