using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	//public float horizontalSpeed = 10;
	//public float verticalSpeed = 10;
	public Rigidbody rb;

	void Update() {
		//float horizontal = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
		//transform.Translate(horizontal, 0, 0);
		rb.MovePosition(transform.position + transform.forward *Input.GetAxis("Vertical")* Time.deltaTime + transform.right *Input.GetAxis("Horizontal")* Time.deltaTime);

		//float vertical = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
		//transform.Translate(0, 0, vertical);
		//rb.MovePosition(transform.position + transform.right *Input.GetAxis("Horizontal")* Time.deltaTime);
	}
}