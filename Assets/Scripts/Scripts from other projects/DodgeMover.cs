using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DodgeMover : MonoBehaviour {

	float speed;
	public float dodgeTime = 20;
	public int dodgeSpeed = 20;
	public int normalSpeed = 5;
	float dodgeTimer;
	public bool dodgeLock = false;
	public bool timerLock = false;
	public bool movementLock = false;
	public Rigidbody rb;
	Vector3 latestMoveDir;
	private AudioSource[] AS;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		AS = GetComponents<AudioSource> ();
		dodgeTimer = dodgeTime;
		speed = normalSpeed;
	}
		
	void Update () 
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");


		if (!movementLock) {
		
			latestMoveDir = Vector3.zero;

			latestMoveDir += Vector3.right * horizontal;

			latestMoveDir += Vector3.forward * vertical;
		}


		if (Input.GetButton ("Dodge") && dodgeLock == false && latestMoveDir != Vector3.zero) {
		speed = dodgeSpeed;
			movementLock = true;
			timerLock = true;
			AS [1].Play ();
			GetComponent<TrailRenderer> ().enabled = true;
		}
			

		if (timerLock == true) {
			dodgeTimer = dodgeTimer - 1;
			dodgeLock = true;
		}

		rb.MovePosition(transform.position + latestMoveDir * speed * Time.deltaTime);

		if (dodgeTimer <= 0) {
			
			speed = 0;
			movementLock = false;

		}
		if (dodgeTimer <= -20) {
			
			timerLock = false;
			dodgeTimer = dodgeTime;
			speed = normalSpeed;
			GetComponent<TrailRenderer> ().enabled = false;
		}
			
		if (dodgeTimer == dodgeTime) {
			
			dodgeLock = false;
			timerLock = false;
		}

		if (movementLock == true) {
			
		}
		else {
			
		}

		//Nomral move
		rb.velocity = Vector3.zero;


	}
}