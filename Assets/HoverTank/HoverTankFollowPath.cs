using UnityEngine;
using System.Collections;

public class HoverTankFollowPath : MonoBehaviour
{

	Vector3 destination = Vector3.zero;
	NavMeshPath path;
	bool CanFindPath = false;
	Vector3[] pathPoints;
	public Rigidbody rigidBody;
	public float distanceThreshold = 5f;

	// Use this for initialization
	void Start ()
	{
		path = new NavMeshPath();
		CalcPath();
		rigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
	{
		//get the path
		if(path.status == NavMeshPathStatus.PathComplete)
		{
			//Get the points
			pathPoints = path.corners;
		}


		if(CanFindPath && pathPoints != null)
		{
			TurnAndMove();
			Debug.DrawLine(transform.position,pathPoints[1]);
			float dist = Vector3.Distance(transform.position,pathPoints[1]);
			//did we get there?
			if(dist < distanceThreshold)
			{
				CanFindPath = false;
				CalcPath();
			}
		}

	}

	//calculate the path obviosly
	void CalcPath()
	{
		//check to see if already at destination
		float dist = Vector3.Distance(transform.position,destination);
		if(dist > distanceThreshold)
		{
		//calculate the path
		if(!NavMesh.CalculatePath(transform.position,destination,NavMesh.AllAreas,path))
		{
			CanFindPath = false;
		}
		else
			CanFindPath = true;
		}

	}

	//set new destination- RTSCamera Script can use this!
	void SetDestination(Vector3 newDestination)
	{
		Debug.Log("New Path");
		destination = newDestination;
		CalcPath();

	}

	void TurnAndMove()
	{
		//turn to face
		Vector3 dir = transform.InverseTransformPoint(pathPoints[1]).normalized;
		if(dir.x > 0.1f)
		{
			//turn right
			rigidBody.AddRelativeTorque(0,1000f* dir.x,0,ForceMode.Force);
		}
		if(dir.x < -0.1f)
		{
			//turn left
			rigidBody.AddRelativeTorque(0,1000f*dir.x,0,ForceMode.Force);
		}
		if(dir.z > 0.80f)
		{
			//move forward if facing
			rigidBody.AddRelativeForce(0,0,50f,ForceMode.Impulse);
		}

	}





}
