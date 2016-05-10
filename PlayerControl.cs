using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

	//Maximum damage until death
	public int maxHits = 1;

	//How fast bullets can be fired. Doesn't seem to change much besides how fast you can tap
	public float firerate = 0.2f;

	//THe laser object
	public GameObject shot;

	//speed that the ship moves per pixel
	public float speed = 10.0f;

	//speed the laser moves at per pixel
	public float laserSpeed;


	//how many hits have been taken since game start
	private int hitsTaken = 0;

	//are you shooting at the moment?
	private bool firing = false;

	
	//called every frame
	void Update () {
		Fire();
		movement();
	}

	//sends the fire command while pressed down and cancels it upon release
	void Fire() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Shoot", .001f, firerate);
		}
		if(Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Shoot");
		}
	}


	//sets movements to depend on the arrow keys. Also restricts movement inside a constrained play area
	void movement(){
		if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <= 4.15) {
			transform.position += Vector3.up * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= -4.15) {
			transform.position += Vector3.down * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= 0) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 8.22) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
	}


	//creates the laser and sets the velocity
	void Shoot() {
		Vector3 laserPos = new Vector3(0,0,0);
		GameObject laser = Instantiate(shot, transform.position+laserPos, Quaternion.Euler(0,0,90)) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector3(-laserSpeed,0,0);
	}


	//when there is a collision if the maximum hits are taken then the ship is destroyed and the game over screen is presented.
	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log("Damage Taken");
		Projectiles incominglaser = collider.gameObject.GetComponent<Projectiles>();
		maxHits -= incominglaser.GetDamage();
		if (maxHits <= 0){
			Destroy(gameObject);
			SceneManager.LoadScene("Game Over");
		}
	}







}
