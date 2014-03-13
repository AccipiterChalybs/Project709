using UnityEngine;
using System.Collections;

public class DropPodDeploy : MonoBehaviour {

	private Transform dropPod;
	public Transform newObject;
	public float speed = -1f;

	// Use this for initialization
	void Start () {
		dropPod = this.GetComponent<Transform> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		dropPod.Translate(new Vector3(0, speed, 0));
	}

	public void collide()
	{
		if (newObject!=null)
		{
			Instantiate (newObject, dropPod.position,
		             Quaternion.identity);
		}
		Destroy (dropPod.gameObject);
	}

	void OnTriggerEnter( Collider enter)
	{
		this.collide();
	}
}
