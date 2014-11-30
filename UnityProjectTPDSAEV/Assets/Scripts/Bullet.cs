using UnityEngine;
using System.Collections;

//Bullets will travel in an straigh line hitting an enemy
//or an obstacle/level bundary
public class Bullet : MonoBehaviour {

	//[HideInInspector]
	public int bulletDamage;

	//[HideInInspector]
	public float bulletSpeed;

	//Target position
	[HideInInspector]
	public Vector3 targetPos;

	// Update is called once per frame
	void Update () {
		transform.Translate((targetPos - transform.position) * bulletSpeed * Time.deltaTime);
	}
}
