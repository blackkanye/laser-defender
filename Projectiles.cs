using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	//amount of damage done(calculated per hit)
	public int damage = 1;

	//function returning the damage for other classes
	public int GetDamage() {
		return damage;
	}


	//Destroy the gameobject upon colliding. Basically a die method with a strange name
	public void Hit() {
		Destroy(gameObject);
	}


	//Projectiles are destroyed upon hitting something
	void OnTriggerEnter2D(Collider2D collider) {
		Destroy(gameObject);
	}
}
