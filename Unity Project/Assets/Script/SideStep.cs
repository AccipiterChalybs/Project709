using UnityEngine;
using System.Collections;

public class SideStep : MonoBehaviour {

	public float sideStepDistance = 10;
	public float sideStepInitialTime = 20;
	public float sideStepCoolDown=100;

	private Vector3 sideStepDirection;
	private float sideStepTimeLeft=0;
	private float sideStepCoolLeft=0;

	private PlayerAnimator playerAnimator;

	public AnimationClip jumpForwardsClip;
	public AnimationClip jumpSideClip;
	public AnimationClip jumpBackwardsClip;


	// Use this for initialization
	void Start () 
	{
		playerAnimator = this.GetComponent<PlayerAnimator> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		int rotation = 0;
		if (Input.GetKeyUp(KeyCode.Space) && sideStepCoolLeft < 1)
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
			if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			{
				rotation=180;
				if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
				{
					rotation=-135;
				}
				if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
				{
					rotation=135;
				}
			}
			if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			{
				rotation=-90;
			}
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			{
				rotation=90;
			}

			switch (rotation)
			{
			case 0:
				playerAnimator.play(jumpForwardsClip, false, true);
				break;
			case 45:
				playerAnimator.play(jumpForwardsClip, false, true);
				break;
			case 90:
				playerAnimator.play(jumpSideClip, false, true);
				break;
			case 135:
				playerAnimator.play(jumpBackwardsClip, false, true);
				break;
			case 180:
				playerAnimator.play(jumpBackwardsClip, false, true);
				break;
			case -135:
				playerAnimator.play(jumpBackwardsClip, false, true);
				break;
			case -90:
				playerAnimator.play(jumpSideClip, true, true);
				break;
			case -45:
				playerAnimator.play(jumpForwardsClip, false, true);
				break;
			}

			sideStepDirection = Quaternion.Euler(0, rotation, 0) * transform.forward;
			sideStepTimeLeft = sideStepInitialTime;
			sideStepCoolLeft = sideStepCoolDown;
		}
		if (sideStepTimeLeft>0)
		{
		   this.GetComponent<CharacterController>().Move(sideStepDirection * (sideStepDistance/(sideStepInitialTime/Time.deltaTime)));
		   sideStepTimeLeft -= Time.deltaTime;
		}
		if (sideStepCoolLeft>0)
		{
			sideStepCoolLeft -= Time.deltaTime;
		}
	}
}
