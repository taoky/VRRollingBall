using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameManager gameManager;
	private Rigidbody rb;
	

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called by selected time
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		if (gameManager.isAlive) {
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed;
			rb.AddForce (movement);
		}
		else {
			rb.velocity = Vector3.zero;
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Cube")) {
			// other.gameObject.SetActive (false);
			float newX = Random.value * 46.0f - 23.0f;
			float newZ = Random.value * 46.0f - 23.0f;
			other.gameObject.transform.position = new Vector3 (newX, 1.0f, newZ);
			gameManager.AddScore (int.Parse(other.gameObject.name.Substring(4)));
		}
		else if (other.gameObject.CompareTag ("Dangerous Cube")) {
			float newX = Random.value * 46.0f - 23.0f;
			float newZ = Random.value * 46.0f - 23.0f;
			other.gameObject.transform.position = new Vector3 (newX, 1.0f, newZ);
			gameManager.DelLife();
		}
		else if (other.gameObject.CompareTag ("XuMing")) {
			float newX = Random.value * 46.0f - 23.0f;
			float newZ = Random.value * 46.0f - 23.0f;
			other.gameObject.transform.position = new Vector3 (newX, 1.0f, newZ);
			gameManager.AddLife();
		}
	}
}
