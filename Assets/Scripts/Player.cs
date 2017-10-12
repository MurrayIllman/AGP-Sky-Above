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

	private void Start()
	{
		if (Camera.main != null)
		{
			m_Cam = Camera.main.transform;
		}

	}

	void FixedUpdate()
	{
		// This make the boss always look at the player
		Target.LookAt (transform);

		float v = Input.GetAxis ("Vertical") * movementSpeed;
		float h = Input.GetAxis ("Horizontal") * movementSpeed;
	
		var moveVectorX = m_Cam.forward * v;
		var moveVectorY = m_Cam.right * h;
		var moveVector = (moveVectorX + moveVectorY).normalized * movementSpeed * Time.deltaTime;

		if (isAutoMoving == false) {
			rb.MovePosition (transform.position + m_Cam.forward * v * Time.deltaTime + m_Cam.right * h * Time.deltaTime);
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
		}
	}
}