using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour
{
	//track enemies and try to shoot them
	GameObject[] enemies;
	public GameObject Target;
	public LaserGunScript LaserGun;
	public float TurnSpeed = 2f;

	// Use this for initialization
	void Start ()
	{
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GetTarget (out Target)) 
		{
			//turn to face enemy
			Vector3 dir = (Target.transform.position - transform.position).normalized;
			Vector3 newdir = Vector3.RotateTowards (transform.forward, dir, TurnSpeed * Time.deltaTime, 0f);
			transform.rotation = Quaternion.LookRotation (newdir, transform.up);
			
			//check it is facing and within range
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 20f)) 
			{
				if (hit.collider.tag == "Enemy") 
				{
					//shoot!!
					LaserGun.FireLaser ();
				}
			}
		}
	}

	bool GetTarget (out GameObject enemy)
	{
		enemy = null;
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		if (enemies.Length > 0) {
			//we have enemies
			float dist = Mathf.Infinity;
			foreach (GameObject g in enemies) {
				float thisdist = (transform.position - g.transform.position).magnitude;
				if (thisdist < dist) {
					//this is the nearest
					enemy = g;
					dist = thisdist;
				}

			}
			return true;
		}
		return false;
	}



}
