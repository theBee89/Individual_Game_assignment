using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaballParticleClass : MonoBehaviour {


	public GameObject MObject;
	public float LifeTime;
	public bool Active{
		get{ return _active;}
		set{ _active = value;
			if (MObject) {
				MObject.SetActive (value);

				if (tr)
					tr.Clear ();

			}
		}
	}
	public bool witinTarget; // si esta dentro de la zona de vaso de vidrio en la meta



	bool _active;
	float delta;
	Rigidbody2D rb;
	TrailRenderer tr;

	void Start () {
		//MObject = gameObject;
		rb = GetComponent<Rigidbody2D> ();
		tr = GetComponent<TrailRenderer> ();
		rb.velocity = new Vector2(0, 5f);
	}

	void Update () {

		if (Active == true) {

			VelocityLimiter ();

			if (LifeTime < 0)
				return;

			if (delta > LifeTime) {
				delta *= 0;
				Active = false;
			} else {
				delta += Time.deltaTime;
			}


		}
		if (transform.position.y > 11 || transform.position.y < -11.5 || transform.position.x > 5.6 || transform.position.x < - 5.6)
		{
			Destroy(gameObject);
		}

	}



	void VelocityLimiter()
	{

		
		Vector2 _vel = rb.velocity;
		if (_vel.y > 5f) {
			_vel.y = 5f;
		}
		rb.velocity = _vel;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ambulance")
		{
			Destroy(gameObject);
		}

		//if (collision.gameObject.tag == "Water")
		//{
			//IgnoreCollision(collision.gameObject);
		//}
		Physics2D.IgnoreLayerCollision(1,4);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Ambulance")
		{
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Fire")
		{
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}


}
