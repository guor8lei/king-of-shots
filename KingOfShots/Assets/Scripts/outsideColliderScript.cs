using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outsideColliderScript : MonoBehaviour {

	private Vector3 pingPongPos = new Vector3 (-4f, 4.892f, 7f);

	// Use this for initialization
	void Start () {
		//scoreScript = board.GetComponent<ScoreBoard> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		other.transform.position = pingPongPos;
		other.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		other.GetComponent<Rigidbody>().isKinematic = true;
	}
	void OnTriggerStay(Collider other) {
	}

}
