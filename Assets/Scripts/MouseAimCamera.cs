using UnityEngine;
using System.Collections;

public class MouseAimCamera : MonoBehaviour {
	public GameObject target;
	public float rotateSpeed = 5;
	Vector3 offset;

	public Transform pivot;

	void Start() {
		offset = target.transform.position - transform.position;
	}
	
	void LateUpdate() {
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		float vertical = -Input.GetAxis("Mouse Y") * rotateSpeed;



		target.transform.Rotate(0, horizontal, 0);
		pivot.Rotate (vertical, 0, 0);

		float desiredAngle = target.transform.eulerAngles.y;
		float desiredLook = target.transform.eulerAngles.x;
		Quaternion rotation = Quaternion.Euler(desiredLook, desiredAngle, 0);
		transform.position = target.transform.position - (rotation * offset);
		
		transform.LookAt (target.transform);

		float minRotation = -45;
		float maxRotation = 45;
		Vector3 currentRotation = transform.localRotation.eulerAngles;
		currentRotation.y = Mathf.Clamp(currentRotation.y, minRotation, maxRotation);
		transform.localRotation = Quaternion.Euler (currentRotation);

	}
}