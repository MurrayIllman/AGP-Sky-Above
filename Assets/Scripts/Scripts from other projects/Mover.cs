using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	private Transform ThisTransform = null;
	public float Speed = 1f;


	// Use this for initialization
	void Start () 
	{
		ThisTransform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ThisTransform.position += ThisTransform.forward * Speed * Time.deltaTime;

	}
}
