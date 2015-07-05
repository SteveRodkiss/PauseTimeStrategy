using UnityEngine;
using System.Collections;

public class LaserGunScript : MonoBehaviour
{

	//prefab for laser
	public GameObject LaserPrefab;
	bool firing = false;
	public float LaserCooldown = 0.2f;
	float LaserDelay = 0f;
	public AudioClip LaserBlastSound;
    
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void FireLaser()
	{
		if(!firing)
		{
			firing = true;
			Instantiate(LaserPrefab,transform.position,transform.rotation);
			GetComponent<AudioSource>().PlayOneShot(LaserBlastSound);
        }
		else
		{
			LaserDelay += Time.deltaTime;
			if(LaserDelay >= LaserCooldown)
			{
				LaserDelay = 0f;
				firing = false;
			}
		}
	}
}
