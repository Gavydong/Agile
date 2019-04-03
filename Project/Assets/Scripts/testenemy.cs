using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;


public class testenemy : MonoBehaviour {
	public GameObject explosion;
    public static float health = 1;
    public float moveSpeed=3;
	// Use this for initialization
	public GameObject bulletPrefab;
	private float firetime;
	// Use this for initialization
	void Start () {
        health = 1;
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
		//Vector3 mousePosition = Input.mousePosition;
		//mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
		float x = Input.GetAxis("Controller X");
		float y = Input.GetAxis("Controller Y");
		//if (x != 0.0f || y != 0.0f) {
		//	angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
			// Do something with the angle here.
	//	}
		Vector2 direction = new Vector2 (
			//mousePosition.x - transform.position.x, 
			//mousePosition.y - transform.position.y
			x,y
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
		if (Input.GetAxis ("FireRT")>0) 
		{
			Instantiate(bulletPrefab, transform.position, transform.rotation);
			firetime = 0;
		}

	}

	void move()
	{
		float h = Input.GetAxisRaw ("Horizontal1");
		transform.Translate (Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
		float v = Input.GetAxisRaw ("Vertical1");
		transform.Translate (Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

	}
    IEnumerator timesleep()
    {

        yield return new WaitForSecondsRealtime(2000);
    }
    private void death()
	{
        health = health - 0.1f;
        if (health <= 0)
        {
            //explosion effect
            Instantiate(explosion, transform.position, transform.rotation);
            //death
            Destroy(gameObject);
            timesleep();
            SceneManager.LoadScene(5);
        }
	}
}
