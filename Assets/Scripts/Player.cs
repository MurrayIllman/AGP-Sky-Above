using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour {

	public Rigidbody rb;
	private Transform m_Cam;
	public float movementSpeed;
	public Transform Target;
	public float chargeSpeed = 0.1f;
	public bool isEvading;
	bool isAutoMoving = false;
	float attackTimer = 0.5f;
	float evadeTimer = 0.0f;
	float recoverTimer = 0.0f;
	Vector2 evadeDirection;
	public int hitPoints = 100;
	public Collider playerHitzone;

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
		float v = Input.GetAxisRaw ("Vertical") * movementSpeed;
		float h = Input.GetAxisRaw ("Horizontal") * movementSpeed;

		rb.velocity = Vector3.zero;

		if (Input.GetKey (KeyCode.Space) && recoverTimer <= 0.0f && evadeTimer <= 0.0f) {
			evadeTimer = 0.09f;
			evadeDirection = new Vector2 (h, v);
			isEvading = true;
		}

		if (evadeTimer > 0.0f) {
			evadeTimer -= Time.deltaTime; //timer counts down

			if (evadeTimer <= 0.0f) //timer reaches 0, do shit
			{
				recoverTimer = 0.7f;
				isEvading = false;
			}
		}

		if (recoverTimer > 0.0f) {

			recoverTimer -= Time.deltaTime;
		}

		if (evadeTimer > 0.0f) {
			v = evadeDirection.y * movementSpeed * 1.02f;
			h = evadeDirection.x * movementSpeed * 1.02f;
		}

		if (recoverTimer > 0.0f) {
			v = 0.0f;
			h = 0.0f;
		}

		if (isEvading) {
			playerHitzone.enabled = false;
		}
		else {
			playerHitzone.enabled = true;
		}
	

		var forward = Vector3.Cross (m_Cam.right, Vector3.up);
		var moveVectorX = forward * v;
		var moveVectorY = m_Cam.right * h;
		var moveVector = (moveVectorX + moveVectorY).normalized * movementSpeed * Time.deltaTime;

		if (isAutoMoving == false) {
			rb.MovePosition(rb.position + forward * v * Time.deltaTime + m_Cam.right * h * Time.deltaTime);
            if (moveVector.sqrMagnitude > 0.0f)
            {
                rb.MoveRotation(Quaternion.LookRotation(new Vector3 (moveVector.x, 0f, moveVector.z)));
            }
		} else {
			var finalPosition = new Vector3 (Target.position.x, transform.position.y, Target.position.z);
			finalPosition = finalPosition + Target.forward;
            rb.MoveRotation(Quaternion.LookRotation(Target.position - rb.position));
            rb.MovePosition(Vector3.MoveTowards (rb.position, finalPosition, chargeSpeed));

			if (rb.position == finalPosition) 
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

		attackTimer -= Time.deltaTime; //timer counts down

		if (attackTimer <= 0) //timer reaches 0, do shit
		{
			attackCollider.enabled = false;
			attackTimer = 0.5f;
		}
	}

	void TakeDamage(int damage)
	{
		if (!isEvading) {
			hitPoints -= damage;
		}
	}
}