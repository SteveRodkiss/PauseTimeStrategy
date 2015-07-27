using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{
	//amount of starting health
	public float Health = 50f;
	
	void TakeDamage(float damage)
	{
		Health -= damage;
	}

	void Update()
	{
		if(Health < 0)
		{
			Destroy(gameObject);
		}
	}
}
