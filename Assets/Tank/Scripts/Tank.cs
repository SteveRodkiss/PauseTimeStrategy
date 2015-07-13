using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Tank : MonoBehaviour
{
	NavMeshAgent nav;
	Vector3 Destination = Vector3.zero;

	// Use this for initialization
	void Start ()
	{
		nav = GetComponent<NavMeshAgent>();
		nav.destination = Destination;
	}


	public void SetDestination(Vector3 d)
	{
		//set the destination for this tank
		nav.SetDestination(d);
	}

}
