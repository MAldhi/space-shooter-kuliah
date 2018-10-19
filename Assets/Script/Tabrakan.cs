using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabrakan : MonoBehaviour {

	public GameObject playerExplosion;
	public GameObject explosion;

	void OnTriggerEnter (Collider other){
		if (other.tag == "Boundary" || other.tag == "Enemy") {
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}

		Destroy (other.gameObject);
		Destroy (gameObject);
	}

}
