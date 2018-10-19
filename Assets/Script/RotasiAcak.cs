using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotasiAcak : MonoBehaviour {

	public float tumble;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble;
	}

}
