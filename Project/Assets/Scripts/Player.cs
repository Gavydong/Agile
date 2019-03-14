using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : MonoBehaviour {
	public float moveSpeed=3;
	// Use this for initialization
	public GameObject bulletPrefab;
	private float firetime;
	public GameObject explosion;
	public float health =5;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (firetime >= 0.3f) 
		{
			attack ();
		} 
		else 
		{
			firetime += Time.deltaTime;
		}
	}
	void faceMouse()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);

		Vector2 direction = new Vector2 (
			                    mousePosition.x - transform.position.x, 
			                    mousePosition.y - transform.position.y
		                    );
		transform.up = direction;

	}
	private void FixedUpdate()
	{
		faceMouse ();
		move ();
	}
	private void attack()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			Instantiate(bulletPrefab, transform.position, transform.rotation);
			firetime = 0;
		}

	}

	void move()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		transform.Translate (Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
		float v = Input.GetAxisRaw ("Vertical");
		transform.Translate (Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
			
	}

	private void death()
	{
		health--;
		if (health == 0) {
			//explosion effect
			Instantiate (explosion, transform.position, transform.rotation);
			//death
			Destroy (gameObject);
		}
	}
}
