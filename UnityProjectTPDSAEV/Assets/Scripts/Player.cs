using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int maxHealth;

	public int currentHealth;
	
	public Weapon mainWeapon;

	[HideInInspector]
	public bool death;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		death = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SubstractHealth(int amount){
		currentHealth -= amount;
		if(currentHealth <= 0){
			death = true;
			//Notify game manager of player death
		}
	}

	public void AddHealth(int amount){
		currentHealth += amount;
		currentHealth = Mathf.Min (currentHealth, maxHealth);
	}
}
