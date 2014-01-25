using UnityEngine;
using System.Collections;

public class SideStep : MonoBehaviour {

	public float sideStepDistance = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float rotation = 0;
		if (Input.GetKeyUp(KeyCode.Space))
		{
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			{
				rotation=0;
				if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
				{
					rotation=-45;
				}
				if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
				{
					rotation=45;
				}
			}
			this.GetComponent<CharacterController>().Move( Quaternion.Euler(0, rotation, 0) * transform.forward );

		}

	}
}
