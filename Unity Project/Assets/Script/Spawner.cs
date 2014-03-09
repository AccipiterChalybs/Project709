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
	private int currSpawned=0;

	public int yOffset;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (spawnEnabled && currCool>=cooldown && currSpawned<max)
		{
			Instantiate (itemToCreate, new Vector3(Random.Range(-xRange, xRange),
			                                       Random.Range(-yRange+yOffset, yRange+yOffset),
			                                       Random.Range(-zRange, zRange)),
			                                       Quaternion.identity);
			currSpawned++;
			currCool = 0;
		}
		currCool += Time.deltaTime;
	}
}
