using UnityEngine;
using System.Collections;

public class HoverTankPlayerControl : MonoBehaviour
{


	Rigidbody rb;
	float torque = 0f;
	float zforce = 0f;
	float xforce = 0f;


	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
	{
		torque = Input.GetAxis("Mouse X") * 50f;
		zforce = Input.GetAxis("Vertical") * 50f;
		xforce = Input.GetAxis("Horizontal") * 50f;
	}

	void FixedUpdate()
	{
		rb.AddRelativeTorque(0,torque,0,ForceMode.Impulse);
		rb.AddRelativeForce(xforce,0,zforce,ForceMode.Impulse);
	}

	void OnApplicationQuit()
	{
		Cursor.lockState = CursorLockMode.None;
	}


}
