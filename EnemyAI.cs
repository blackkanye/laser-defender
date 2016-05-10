using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	//the enemy laser object
	public GameObject lazer;

	//speed of enemy lasers
	public float lazerSpeed = 10f;

	//maximum hits the enemy can take
	public int maxHits = 0;

	//how often the enemy shoots
	public float shotsPerSeconds = 0.5f;

	//Amount of points the enemy is worth
	public int scoreValue = 150;


	//make an object based off scorekeeper
	private ScoreKeeper scoreKeeper;

	//Find Score method
	void Start () {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	//randomize how often enemies shoot
	void Update () {
		float probability = Time.deltaTime * shotsPerSeconds;
		if(Random.value < probability) {
			Fire();
		}
	}

	//instantiate enemy lasers and set their speed
	void Fire() {
		Vector3 spawnPosition = transform.position + new Vector3(0,0,0);
		GameObject missile = Instantiate(lazer, transform.position, Quaternion.Euler(0,0,-90f)) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2(lazerSpeed, 0);
	}


	//upon taking the maxHits the enemy is destroyed
	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log("Damage Taken");
		Projectiles bullet = collider.gameObject.GetComponent<Projectiles>();

		if(bullet) {
			maxHits -= bullet.GetDamage();
			if(maxHits <= 0) {
				Die();
			}
		}
	}


	//Destroy the ship and send the Score to the Game Over Screen
	void Die() {
		Destroy(gameObject);
		scoreKeeper.Score(scoreValue);
	}

}
