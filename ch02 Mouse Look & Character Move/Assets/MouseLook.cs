using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseX;

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float rotationX = 0.0f;

	// Use this for initialization
	void Start () {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }		
	}
	
	// Update is called once per frame
	void Update () {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

            transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0);
            Debug.Log(transform.localEulerAngles.x + "vs." + rotationX.ToString());

            /*
            // bug version: transform.localEulerAngles.x: [0, 360]
            float xAngle = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * sensitivityVert;
            xAngle = Mathf.Clamp(xAngle, minimumVert, maximumVert);
            */
        }
        else
        {
            float rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityHor;

            rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
	}
}
