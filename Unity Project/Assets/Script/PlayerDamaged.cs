using UnityEngine;
using System.Collections;

public class PlayerDamaged : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void damage()
	{
		this.GetComponent<CharacterController>().Move (this.transform.forward * -30);
		this.transform.rotation = Quaternion.identity;
	}
}
