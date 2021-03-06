﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public int maxAmmo;
	[HideInInspector]
	public int currentAmmo;

	public float shootCoolDownTime;
	private bool canShoot;

	//Bullet prefab
	public GameObject bullet;
	public int bulletDamage;
	public float bulletSpeed;

	// Use this for initialization
	void Start () {
		currentAmmo = maxAmmo;
		canShoot = true;

		//Optimizaction
		//Pool of bullets to recycle them and avoid GC
		bullet.CreatePool (20);
	}

	public bool CanShoot()
	{
		if(canShoot && currentAmmo > 0)
			return true;
		else
			return false;
	}

	private GameObject tempBullet;
	public void Shoot(Vector3 bulletPos, Quaternion rotation)
	{
		//Instantiate bullet on bulletPos position with the current player rotation
		//Inmprovement: Use of pool to instantiate bullets
		//tempBullet = GameObject.Instantiate (bullet, bulletPos, rotation) as GameObject;
		tempBullet = bullet.Spawn (bulletPos, rotation);

		//Set values again as we are recycling bullets
		//and to secure weapon values are set
		tempBullet.GetComponent<Bullet> ().bulletDamage = bulletDamage;
		tempBullet.GetComponent<Bullet> ().bulletSpeed = bulletSpeed;

		currentAmmo--;

		canShoot = false;

		//Allow weapon shoot after cooldown time
		Invoke ("ResetShootCoolDown", shootCoolDownTime);
	}

	public void ResetShootCoolDown()
	{
		canShoot = true;
	}

	public void Recharge(int ammoAdd)
	{
		currentAmmo += ammoAdd;
		currentAmmo = Mathf.Min (currentAmmo, maxAmmo);
	}

	public void FullRecharge()
	{
		Recharge (maxAmmo);
	}
}
