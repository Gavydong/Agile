using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar1 : MonoBehaviour {
	Vector3 localScale;
	//float scale = 0.05;
		// Use this for initialization
	void Start () {
		localScale = transform.localScale;
	}

		// Update is called once per frame
	void Update () {
		localScale.x = Player.health* (float)0.05;
		transform.localScale = localScale;
	}
}
