using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

    Vector3 tempVec3;
	// Use this for initialization
	void Start () {

        this.transform.position = new Vector3(0.0f, 20.0f, -60.0f);
        this.transform.LookAt(new Vector3(0.0f, 10.0f, 0.0f));


//         float[] distances = new float[32];
//         distances[8] = 500.0f;
//         Camera camera = GetComponent<Camera>();
//         camera.layerCullDistances = distances;
        tempVec3 = new Vector3();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LateUpdate()
    {
		if(Input.touchCount > 0)
		{
			if (Input.GetTouch (0).phase == TouchPhase.Moved) 
			{
				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
				if (touchDeltaPosition.x > 0) 
				{
					transform.Rotate(Vector3.up, (float)Time.deltaTime * 30.0f, Space.World);
				}
				if (touchDeltaPosition.x < 0) 
				{
					transform.Rotate(-Vector3.up, (float)Time.deltaTime * 30.0f, Space.World);
				}

				if (touchDeltaPosition.y > 0) 
				{
                    tempVec3.Set(-1.0f, 0.0f, 0.0f);
                    transform.Rotate(tempVec3, (float)Time.deltaTime * 30.0f, Space.Self);
				}
				if (touchDeltaPosition.y < 0) 
				{
                    tempVec3.Set(1.0f, 0.0f, 0.0f);
                    transform.Rotate(tempVec3, (float)Time.deltaTime * 30.0f, Space.Self);
				}
			}
		}
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Rotate(-Vector3.up, (float)Time.deltaTime * 100.0f, Space.World);
            }
            else
            {
                tempVec3.Set(-0.5f, 0.0f, 0.0f);
                transform.Translate(tempVec3, Space.Self);

            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Rotate(Vector3.up, (float)Time.deltaTime * 100.0f, Space.World);
            }
            else
            {
                tempVec3.Set(0.5f, 0.0f, 0.0f);
                transform.Translate(tempVec3, Space.Self);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tempVec3.Set(0.0f, 0.0f, 1.0f);
            Vector3 vDir = transform.TransformDirection(tempVec3);
            vDir.y = 0.0f;
            transform.Translate(vDir*0.5f, Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tempVec3.Set(0.0f, 0.0f, -1.0f);
            Vector3 vDir = transform.TransformDirection(tempVec3);
            vDir.y = 0.0f;
            transform.Translate(vDir*0.5f, Space.World);
        }

        if (Input.GetKey(KeyCode.PageUp))
        {
            tempVec3.Set(0.0f, 1.0f, 0.0f);
            transform.Translate(tempVec3, Space.World);
        }

        if (Input.GetKey(KeyCode.PageDown))
        {
            tempVec3.Set(0.0f, -1.0f, 0.0f);
            transform.Translate(tempVec3, Space.World);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            tempVec3.Set(1.0f, 0.0f, 0.0f);
            transform.Rotate(tempVec3, (float)Time.deltaTime * 100.0f, Space.Self);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            tempVec3.Set(-1.0f, 0.0f, 0.0f);
            transform.Rotate(tempVec3, (float)Time.deltaTime * 100.0f, Space.Self);
        }


    }
}
