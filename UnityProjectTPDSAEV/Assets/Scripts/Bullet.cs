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
	void Start () {
		//(targetPos - transform.position)
		//transform.Translate(new Vector3(Mathf.Cos(Mathf.Deg2Rad * transform.localEulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.localEulerAngles.z ), 0.0f));
		rigidbody2D.AddForce(transform.up * bulletSpeed);
	}
}
