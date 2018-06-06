using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {
	public int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
			this.transform.GetChild (0).gameObject.GetComponent <TextMesh>().text = score.ToString();
	}
}
