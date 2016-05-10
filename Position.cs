using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	//This adds a circle with the center being the x and y used for objects spawned in it
	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}
