using UnityEngine;
using System.Collections;

public class HeightFinder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<CharacterController>().height = transform.FindChild("Character").collider.bounds.size.y;
		print (transform.Find ("Character").collider.bounds.size.y);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
