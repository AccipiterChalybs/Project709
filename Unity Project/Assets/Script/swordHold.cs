using UnityEngine;
using System.Collections;

public class swordHold : MonoBehaviour {

	public Transform bone;

	// Use this for initialization
	void Start () 
	{
		Transform transf = this.GetComponent<Transform> ();
		transf.position = bone.position;
		transf.rotation = (bone.rotation);
		transf.parent = bone;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
