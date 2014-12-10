using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int maxHealth;

	public int currentHealth;
	
	public Weapon mainWeapon;

	[HideInInspector]
	public bool death;

	private Text heroHealth;

	// Use this for initialization
	void Start () {
		//Store HumanDescription health
		heroHealth = GameObject.Find ("HeroHealth").GetComponent<Text> ();

		Debug.Log(GameObject.Find ("HeroHealth").ToString());

		AddHealth (maxHealth);
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

		//Update health HUD
		heroHealth.text = "Health: " + currentHealth.ToString ();
	}

	public void AddHealth(int amount){
		currentHealth += amount;
		currentHealth = Mathf.Min (currentHealth, maxHealth);

		//Update health HUD
		heroHealth.text = "Health: " + currentHealth.ToString ();
	}
}
