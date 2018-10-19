using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Batas{
	public float xMin, xMax, zMin, zMax;
}

public class gerakPlayer : MonoBehaviour {

	public float speed;
	public float tilt;
	public Batas boundary;

	public GameObject tembakan;
	public Transform spawnTembakan;
	public float lajupeluru;
	private float tembakanBerikut;

	Rigidbody rBody;
	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody>();
		if (rBody == null) ;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > tembakanBerikut) {
			tembakanBerikut = Time.time + lajupeluru;
			Instantiate (tembakan, spawnTembakan.position, spawnTembakan.rotation);
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rBody.velocity = movement * speed;

		rBody.position = new Vector3
			(
				Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp(rBody.position.z, boundary.zMin, boundary.zMax)
			);

		rBody.rotation = Quaternion.Euler(0.0f, 0.0f, rBody.velocity.x * -tilt);
	}
}
