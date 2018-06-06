using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderScript : MonoBehaviour {

	public GameObject board;
	private Vector3 pingPongPos = new Vector3 (-4f, 4.892f, 7f);
	public GameObject parentCup;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		
	}
	void OnTriggerStay(Collider other) {
		board.GetComponent<ScoreBoard> ().score += 1;
		print (board.GetComponent<ScoreBoard> ().score);
		other.transform.position = pingPongPos;
		other.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		other.GetComponent<Rigidbody>().isKinematic = true;
		parentCup.active = false;
	}

}
