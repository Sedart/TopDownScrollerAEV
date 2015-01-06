using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Player player;

	public float playerMoveSpeed;
	public float playerRotateSpeed;

	private Transform bulletSpawnPos;

	public float dashForce;

	// Use this for initialization
	void Start () {
		bulletSpawnPos = GameObject.Find ("Hero/MainWeapon/BulletSpawnPos").transform;
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

		//Recharge weapon if e button us pressed
		if(Input.GetKey(KeyCode.E))
		{
			player.mainWeapon.FullRecharge();
		}
		#endregion

		#region basic dash ability
		//Dash hero in the direction it is aiming
		if(Input.GetKeyDown(KeyCode.Mouse1)){
			gameObject.rigidbody2D.AddForce((mousePos - transform.position).normalized * dashForce, ForceMode2D.Impulse);
		}
		#endregion
	}
}
