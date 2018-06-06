using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

	public Vector3 holdPosition = new Vector3(0, -0.025f, 0.03f);
	public Vector3 holdRotation = new Vector3(0, 180, 0);

	private bool holdingPingPong = false;

	private GameObject pingPong = null;

	public OVRInput.Controller controller;

	private float handTriggerState = 0;

	// Update is called once per frame
	void Update() {
		handTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);

		if (holdingPingPong) {
			PingPong pingPongScript = pingPong.GetComponent<PingPong>();

			if (handTriggerState < 0.9f) {
				ReleaseBall ();
			}
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.CompareTag("PingPong")) {
			// print ("touching ball");
			if (handTriggerState > 0.9f && !holdingPingPong) {
				Grab(other.gameObject);
			}
		}
	}

	void Grab(GameObject obj) {
		holdingPingPong = true;
		pingPong = obj;

		pingPong.transform.parent = transform;

		pingPong.transform.localPosition = holdPosition;
		pingPong.transform.localEulerAngles = holdRotation;

		pingPong.GetComponent<Rigidbody>().useGravity = false;
		pingPong.GetComponent<Rigidbody>().isKinematic = true;
	}

	void ReleaseBall() {
		pingPong.transform.parent = null;

		Rigidbody rigidbody = pingPong.GetComponent<Rigidbody>();

		rigidbody.useGravity = true;
		rigidbody.isKinematic = false;

		rigidbody.velocity = Vector3.Scale (OVRInput.GetLocalControllerVelocity (controller), new Vector3 (-3, 3, -3));

		holdingPingPong = false;
		pingPong = null;
	}
}