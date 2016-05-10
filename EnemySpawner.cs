using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	//enemy precreated object
	public GameObject enemyPrefab;

	//predetermined size of the spawn container
	public float width = 10f;
	public float height = 5f;

	//speed that the enemies move side to side
	public float speed = 5f;

	//how much time between each spawn there should be
	public float spawnDelay = 0.5f;

	//the group of enemies is moving up
	private bool movingUp = true;

	//minimum and maximum movement space
	private float yminimum;
	private float ymaximum;

	//establish the maximum and minimum and then spawn enemies in all available spots
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distanceToCamera));


		yminimum = leftBoundary.x;
		ymaximum = rightBoundary.x;
		spawnInAllSpots();
	}


	//creates enemies in positions indicated by the positioners
	void spawnInAllSpots() {
		Transform freeSpot = NextSpot();
		if(freeSpot){
			GameObject enemy = Instantiate( enemyPrefab, freeSpot.position, Quaternion.Euler(transform.position.x,transform.position.y,-90)) as GameObject;
			enemy.transform.parent = freeSpot;
		}
		if(NextSpot()){
			Invoke("spawnInAllSpots", spawnDelay);
		}
	}


	//figure out what the next spot to spawn an enemy in is
	Transform NextSpot() {
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}



	//makes the box of the enemies movement appear in the editor
	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

	
	// move the enemies up and down. ALso respawn enemies all enemies in a group are gone.
	void Update () {
		if(movingUp){
			transform.position += Vector3.up * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.down * speed * Time.deltaTime;
		}

		float upperSideOff = transform.position.y + (0.72f*height);
		float lowerSideOff = transform.position.y - (0.72f*height);

		if(lowerSideOff < yminimum) {
			movingUp = true;
		} else if(upperSideOff > ymaximum) {
			movingUp = false;
		}

		if(AllDead()) {
			spawnInAllSpots();
		}
		
	}


	//check if all of the enemies in a group are dead
	bool AllDead() {
		foreach(Transform childPositionGameObject in transform) {
			if(childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
