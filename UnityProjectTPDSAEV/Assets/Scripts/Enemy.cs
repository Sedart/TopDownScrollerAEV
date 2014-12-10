using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int maxHealth;
	[HideInInspector]
	public int currentHealth;
	
	public Weapon mainWeapon;

	[HideInInspector]
	public bool death;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SubstractHealth(int amount){
		currentHealth -= amount;
		if(currentHealth <= 0){
			death = true;
			//Notify game manager of enemy death
			GameObject.Find("GameManager").GetComponent<GameManager>().EnemyKilled();

			//Destroy enemy
			Destroy(gameObject);
		}
	}
	
	public void AddHealth(int amount){
		currentHealth += amount;
		currentHealth = Mathf.Min (currentHealth, maxHealth);
	}
}
