using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("a"))
        {
            Camera.main.transform.Rotate(0, -100 * Time.deltaTime, 0, Space.World);
            //print("space key was pressed");
        } else if (Input.GetKey("d"))
        {
            Camera.main.transform.Rotate(0, 100 * Time.deltaTime, 0, Space.World);
            //print("space key was pressed");
        }
        else if (Input.GetKey("s"))
        {
            Camera.main.transform.Rotate(100 * Time.deltaTime, 0, 0, Space.World);
            //print("space key was pressed");
        }
        else if (Input.GetKey("w"))
        {
            Camera.main.transform.Rotate(-100 * Time.deltaTime, 0, 0, Space.World);
            //print("space key was pressed");
        }
    }
}
