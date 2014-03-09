using UnityEngine;
using System.Collections;

public class DamagesEnemies : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		print ("hit");
		if (other.gameObject.tag=="Enemy")
		{
			print ("Ahit");
			other.transform.position = new Vector3 (Random.Range (-30, 30),
		                    	                    20,
		                        	                Random.Range (-30, 30));
		}

	}
}
