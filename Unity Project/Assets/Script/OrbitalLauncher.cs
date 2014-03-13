using UnityEngine;
using System.Collections;

public class OrbitalLauncher : MonoBehaviour {

	public Transform objectToFire;
	public Vector3 initialOffset;
	public Vector3 targetCenter;
	public Vector3 acceptableError;

	public bool fireEnabled;
	public float cooldown;
	private float currCool;
	public bool unlimitedAmmo = false;
	public int maxNumber = 5;
	public static int __currSpawned;
	public bool useLocations=false;
	private ArrayList fireLocations;

	// Use this for initialization
	void Start () 
	{
		if (useLocations)
		{
			fireLocations = new ArrayList();
			foreach (Transform child in this.transform){
				if (child.name == "FireSpot")
				{
					fireLocations.Add(child);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (fireEnabled && currCool>=cooldown && (__currSpawned < maxNumber || unlimitedAmmo))
		{
			Vector3 loc;
			if (useLocations && fireLocations.Count > 0 )
			{
				loc = ((Transform)fireLocations[Random.Range(0, fireLocations.Count-1)]).position;
			}
			else
			{
				loc = this.transform.position + initialOffset;
			}

			Vector3 targetPoint = targetCenter + 
				new Vector3(Random.Range(-acceptableError.x, acceptableError.x),
				            Random.Range(-acceptableError.y, acceptableError.y),
				            Random.Range(-acceptableError.z, acceptableError.z));

			Instantiate (objectToFire,
			             loc,
			             Quaternion.LookRotation(new Vector3(-targetPoint.x + loc.x,
			                                                 -targetPoint.y + loc.y,
			                                                 -targetPoint.z + loc.z))* Quaternion.Euler(90,0,0));
			if (!unlimitedAmmo)
			{
				__currSpawned++;
			}
			currCool = 0;
		}
		currCool += Time.deltaTime;	
	}
}
