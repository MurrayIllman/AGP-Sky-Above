using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour {

	public Rigidbody rb;
	private Transform m_Cam;
	public float movementSpeed;

	private void Start()
	{
		if (Camera.main != null)
		{
			m_Cam = Camera.main.transform;
		}
			
	}

	void FixedUpdate()
	{
		float v = Input.GetAxis ("Vertical")*movementSpeed;
		float h = Input.GetAxis ("Horizontal")*movementSpeed;
	
		var moveVectorX = m_Cam.forward * v;
		var moveVectorY = m_Cam.right * h;
		var moveVector = ( moveVectorX + moveVectorY ).normalized * movementSpeed * Time.deltaTime;
		rb.MovePosition(transform.position + m_Cam.forward *v* Time.deltaTime + m_Cam.right *h* Time.deltaTime);
		transform.LookAt(transform.position + new Vector3( moveVector.x, 0f, moveVector.z ));
	}
}