using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patternTwo : MonoBehaviour, IAttack {

	public float rotationSpeed = 10;

	public IEnumerator Attack () {
		float rotation = 0.0f;

		while (rotation < 360.0f) {

			rotation += rotationSpeed * Time.deltaTime;
			transform.localRotation = Quaternion.Euler (0.0f, -rotation, 0.0f);
			yield return null;
		}

		transform.localRotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);

	}
}
