using UnityEngine;
using System.Collections;

public class HoverTankControl : MonoBehaviour {

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis("Horizontal") * 50f;
		float z = Input.GetAxis("Vertical") * 50f;
		rb.AddRelativeTorque(0,x,0,ForceMode.Impulse);
		rb.AddRelativeForce(0,0,z,ForceMode.Impulse);
	}
}
