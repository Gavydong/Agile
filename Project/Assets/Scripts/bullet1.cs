using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1 : MonoBehaviour {

	public float moveSpeed =8;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Translate (transform.up * moveSpeed * Time.deltaTime, Space.World);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		switch (collision.tag) 
		{
		case "player2":
			break;
		case "player1":
			collision.SendMessage ("death");
			Destroy (gameObject);
			break;
		case "wall":
			Destroy (collision.gameObject);
			Destroy (gameObject);
			break;
		case "barrier":
			Destroy (gameObject);
			break;
		default:
			break;

		}
	}
}
