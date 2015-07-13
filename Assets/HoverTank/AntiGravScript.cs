using UnityEngine;
using System.Collections;

public class AntiGravScript : MonoBehaviour
{
	LayerMask layerMask;
	public Rigidbody rigidBody;
	public float HoverDistance = 2f;
	public float HoverForce = 100f;

	// Use this for initialization
	void Start ()
	{
		layerMask = 1 << LayerMask.NameToLayer("HoverTank");
		layerMask = ~layerMask;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//get distance from ground
		Ray ray = new Ray(transform.position,Vector3.down);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit,HoverDistance * 2f,layerMask))
		{
			//we have hit something under us
			float CurrentHeight = hit.distance;
			//adjust depending on distance
			float CurrentForce =  HoverForce * (1.0f - (CurrentHeight / HoverDistance));
			//apply force
			rigidBody.AddForceAtPosition(CurrentForce * Vector3.up,transform.position);
		}
		else
		{
			//check if upside down?
			if(transform.up.y < 0f)
			{
				rigidBody.AddTorque(0,0,HoverForce*10f);
			}

		}
	}
}
