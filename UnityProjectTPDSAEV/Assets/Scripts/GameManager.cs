using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public int totalEnemiesDefeated;

	public int enemiesByWave;
	public int enemiesIncrementByWave;
	public float cooldownBetweenWaves;

	public List <Transform> enemySpawners;

	public GameObject enemyPrefab;

	//Wave info
	public int currentWave;
	public int currentWaveEnemiesSpawned;
	public int currentWaveEnemiesDefeated;

	//Player reference, necessary to chek if player is death
	private Player player;

	// Use this for initialization
	void Start () {
		//Game Manager initialization
		totalEnemiesDefeated = 0;
		enemiesByWave = 4;
		enemiesIncrementByWave = 4;

		cooldownBetweenWaves = 5.0f;

		//Wave info initialization
		currentWave = 0;

		//Player reference
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

		player.transform.position = new Vector2 (0.0f, 0.0f);

		//Start enemy waves
		SpawnSomeEnemyWaves ();
	}
	
	// Update is called once per frame
	void Update () {
		//If players dies reestart the game
		//or show restart pop up
		if(player.death)
			Start ();
	}

	//Called when all enemies of the last wave are killed
	public void NextWave(){
		currentWave++;
		currentWaveEnemiesDefeated = 0;
		currentWaveEnemiesSpawned = 0;
		enemiesByWave += enemiesIncrementByWave;

		player.AddHealth (player.maxHealth);

		SpawnSomeEnemyWaves ();
	}

	//Spawns some enemies at random spawners
	//until all the enemies of the wave are spawned
	public void SpawnSomeEnemyWaves(){
		GameObject spawnedEnemy;
		if(currentWaveEnemiesSpawned < enemiesByWave){
			for(int i = 0; i < (int) (enemiesByWave/4); i++){
				//Change instantiate call with object pool call
				spawnedEnemy = GameObject.Instantiate(enemyPrefab, enemySpawners[Random.Range(0, 4)].position, Quaternion.identity) as GameObject;
				spawnedEnemy.GetComponent<EnemyController>().targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
				currentWaveEnemiesSpawned++;
			}

			Invoke("SpawnSomeEnemyWaves", cooldownBetweenWaves);
		}else{
			//All enmies of the wave have been spawned
			if(currentWaveEnemiesDefeated >= enemiesByWave){
				NextWave();
				Debug.Log("INITIATING NEXT WAVE");
			}else{
				//Wait for player to defeat all enemies
				Invoke("SpawnSomeEnemyWaves", cooldownBetweenWaves);
			}
		}
	}

	//Update enemy kills counters
	public void EnemyKilled(){
		totalEnemiesDefeated++;
		currentWaveEnemiesDefeated++;
	}
}
