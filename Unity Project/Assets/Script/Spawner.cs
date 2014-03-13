using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public Transform itemToCreate;
	public int xRange, yRange, zRange;
	public bool spawnEnabled = true;
	public float cooldown=1;
	private float currCool = 0;
	public int max=20;
	public static int __currSpawned=0;

	public int yOffset;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (spawnEnabled && currCool>=cooldown && __currSpawned<max)
		{
			Instantiate (itemToCreate, new Vector3(Random.Range(-xRange, xRange),
			                                       Random.Range(-yRange+yOffset, yRange+yOffset),
			                                       Random.Range(-zRange, zRange)),
			                                       Quaternion.identity);
			__currSpawned++;
			currCool = 0;
		}
		currCool += Time.deltaTime;
	}
}
