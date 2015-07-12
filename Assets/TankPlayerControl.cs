using UnityEngine;
using System.Collections;

public class TankPlayerControl : MonoBehaviour
{
	public WheelCollider[] RightWheels;
	public WheelCollider[] LeftWheels;
	public float MotorPower = 500f;
	public float right = 0f;
	public float left = 0f;
	//maximum speed for wheels to go at. This is used to simulate mechnical drag
	public float MaxRPM = 100f;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		right = 0;
		left = 0;

		if(Input.GetKey(KeyCode.P))
		{
			right = MotorPower;
		}
		if(Input.GetKey(KeyCode.L))
		{
			right = -MotorPower;
		}
		if(Input.GetKey(KeyCode.Q))
		{
			left = MotorPower;
		}
		if(Input.GetKey(KeyCode.A))
		{
			left = -MotorPower;
		}

		foreach(WheelCollider lw in LeftWheels)
		{
			if(left != 0)
			{
				lw.motorTorque = left - (left * Mathf.Abs(lw.rpm / MaxRPM));
				lw.brakeTorque = 0f;
			}
			else
			{
				lw.brakeTorque = MotorPower * 10f;
				lw.motorTorque = 0f;
			}
		}

		foreach(WheelCollider rw in RightWheels)
		{
			if(right != 0)
			{
				rw.motorTorque = right  - (right * Mathf.Abs(rw.rpm / MaxRPM));
				rw.brakeTorque = 0f;
			}
			else
			{
				rw.brakeTorque = MotorPower * 10f;
				rw.motorTorque = 0f;
			}
		}


	}
}
