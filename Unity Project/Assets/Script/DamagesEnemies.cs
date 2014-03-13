using UnityEngine;
using System.Collections;

public class DamagesEnemies : MonoBehaviour {

	public bool attacking;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag=="Enemy" && attacking)
		{
			OrbitalLauncher.__currSpawned --;
			Destroy (other.gameObject);
		}

	}
}
