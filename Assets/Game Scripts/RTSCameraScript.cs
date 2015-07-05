using UnityEngine;
using System.Collections;

public class RTSCameraScript : MonoBehaviour
{
	//the player's tank sript so we can set destination
	Tank player;

	public float MoveSpeed = 10f;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Tank").GetComponent<Tank>();
		if(player == null)
		{
			Debug.Log("Can't find player");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveCamera();
		Vector3 clickpos;
		if(GetClick(out clickpos))
		{
			player.SetDestination(clickpos);
		}
	}

	void MoveCamera()
	{
		//move the camera around
		float xmove = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
		float zmove = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
		float ymove = Input.GetAxis("Mouse ScrollWheel") * MoveSpeed * 100f * Time.deltaTime;
		transform.position += new Vector3(xmove,ymove,zmove);

	}

	bool GetClick(out Vector3 clickpos)
	{
		clickpos = Vector3.zero;
		//get the mouse click position
		if(Input.GetMouseButtonDown(0))
		{
			//cast a ray and set clickpos to hitpoint
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit,100f))
			{
				clickpos = hit.point;
				return true;
			}
		}
		return false;
	}


}
