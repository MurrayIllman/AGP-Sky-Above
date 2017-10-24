using UnityEngine;
using System.Collections;

public class MouseAimCamera : MonoBehaviour {
	public GameObject target;
	public float rotateSpeed = 5;
	public float distance = 10.0f;
	public float pitch = 0.0f;
	public float angle = 0.0f;

	void Update() {
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		float vertical = -Input.GetAxis("Mouse Y") * rotateSpeed;

		float minRotation = 2;
		float maxRotation = 81;
		angle += horizontal;
		pitch = Mathf.Clamp (pitch + vertical, minRotation, maxRotation);

		transform.position = target.transform.position - Quaternion.Euler(pitch, angle, 0.0f) * Vector3.forward * distance;
		transform.LookAt (target.transform);
	}
}