using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour {

	public Rigidbody rb;
	private Transform m_Cam;
	public float movementSpeed;
	public Transform Target;
	public float chargeSpeed = 0.1f;
	bool isAutoMoving = false;
	float comboTimer = 0.5f;
	float dodgeTimer = 0.0f;
	float recoverTimer = 0.0f;
	Vector2 dodgeDirection;

	Collider attackCollider;
	//attackCode aCode;

	private void Start()
	{
		//aCode = GetComponentInChildren<attackCode> ();
		//aCode.enabled = false;
		attackCollider = GetComponentInChildren<BoxCollider>();

		if (Camera.main != null)
		{
			m_Cam = Camera.main.transform;
		}

	}

	void FixedUpdate()
	{
		// This make the boss always look at the player
		Target.LookAt (transform);

		float v = Input.GetAxisRaw ("Vertical") * movementSpeed;
		float h = Input.GetAxisRaw ("Horizontal") * movementSpeed;

		if (Input.GetKey (KeyCode.Space) && recoverTimer <= 0.0f && dodgeTimer <= 0.0f) {
			dodgeTimer = 0.3f;
			dodgeDirection = new Vector2 (h, v);
		}

		if (dodgeTimer > 0.0f) {
			dodgeTimer -= Time.deltaTime; //timer counts down

			if (dodgeTimer <= 0.0f) //timer reaches 0, do shit
			{
				recoverTimer = 0.7f;
			}
		}

		if (recoverTimer > 0.0f) {

			recoverTimer -= Time.deltaTime;
		}

		if (dodgeTimer > 0.0f) {
			v = dodgeDirection.y * movementSpeed * 2.0f;
			h = dodgeDirection.x * movementSpeed * 2.0f;
		}

		if (recoverTimer > 0.0f) {
			v = 0.0f;
			h = 0.0f;
		}

		var forward = Vector3.Cross (m_Cam.right, Vector3.up);
		var moveVectorX = forward * v;
		var moveVectorY = m_Cam.right * h;
		var moveVector = (moveVectorX + moveVectorY).normalized * movementSpeed * Time.deltaTime;

		if (isAutoMoving == false) {
			rb.MovePosition (transform.position + forward * v * Time.deltaTime + m_Cam.right * h * Time.deltaTime);
			transform.LookAt (transform.position + new Vector3 (moveVector.x, 0f, moveVector.z));
		} else {
			var finalPosition = new Vector3 (Target.position.x, transform.position.y, Target.position.z);
			finalPosition = finalPosition + Target.forward;
			transform.position = Vector3.MoveTowards (transform.position, finalPosition, chargeSpeed);
			transform.LookAt (finalPosition);

			if (transform.position == finalPosition) 
			{
				isAutoMoving = false;
			}
		}

		// If leftClick activate the auto movement
		if (Input.GetButtonUp("Fire1"))
		{
			isAutoMoving = true;
			attackCollider.enabled = true;
			//aCode.enabled = true;
		}

		comboTimer -= Time.deltaTime; //timer counts down

		if (comboTimer <= 0) //timer reaches 0, do shit
		{
			attackCollider.enabled = false;
			comboTimer = 0.5f;
		}
	}
}