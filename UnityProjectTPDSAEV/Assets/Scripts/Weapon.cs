using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public int maxAmmo;
	[HideInInspector]
	public int currentAmmo;

	public int bulletDamage;

	public float shootCoolDownTime;
	private bool canShoot;

	//Bullet prefab
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		currentAmmo = maxAmmo;
		canShoot = true;
	}

	public bool CanShoot()
	{
		if(canShoot && currentAmmo > 0)
			return true;
		else
			return false;
	}

	public void Shoot(Vector3 bulletPos, Quaternion rotation)
	{
		//Instantiate bullet on bulletPos position with the current player rotation
		//Inmprovement: Use of pool to instantiate bullets
		GameObject.Instantiate (bullet, bulletPos, rotation);
		currentAmmo--;

		canShoot = false;

		//Allow weapon shoot after cooldown time
		Invoke ("ResetShootCoolDown", shootCoolDownTime);
	}

	public void ResetShootCoolDown()
	{
		canShoot = true;
	}
}
