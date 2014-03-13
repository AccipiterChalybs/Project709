using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour 
{
	public const string ATTACK_INPUT = "Fire1";
	public const string SIDE_STEP_INPUT = "Jump";

	private bool actionInProgress = false;


	private bool sideStepping;
	public float sideStepDistance = 10;
	public float sideStepInitialTime = 0.7f;
	public float sideStepCoolDown=0.5f;
	
	private Vector3 sideStepDirection;
	private float sideStepTimeLeft=0;
	private float sideStepCoolLeft=0;
	
	private PlayerAnimator playerAnimator;
	
	public AnimationClip jumpForwardsClip;
	public AnimationClip jumpSideClip;
	public AnimationClip jumpBackwardsClip;


	public AnimationClip attackAnim;
	
	public Transform faceDirection;
	
	public Transform swordToEnable;
	
	public float attackDistance = 10f;
	public float attackTime = 0.7f;
	public float attackCoolDown = 0.5f;
	private float attackTimeLeft;
	private float attackCoolLeft;
	private Vector3 attackDirection;
	
	private bool attacking;

	// Use this for initialization
	void Start () 
	{
		playerAnimator = this.GetComponent<PlayerAnimator> ();		
	}

	
	// Update is called once per frame
	void Update () 
	{
		/****************** SIDE STEP **************************************/
		int rotation = 0;
		if (!actionInProgress && Input.GetAxis(SIDE_STEP_INPUT)>0 && 
		    sideStepCoolLeft < 1)
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
	//		actionInProgress = true;
			sideStepping = true;
		}
		
		if (sideStepping)
		{
			if (sideStepTimeLeft>0)
			{
				this.GetComponent<CharacterController>().Move(sideStepDirection * (sideStepDistance/(sideStepInitialTime/Time.deltaTime)));
				sideStepTimeLeft -= Time.deltaTime;
			}
			else
			{
				sideStepping=false;
	//			actionInProgress=false;
			}
		}
		if (sideStepCoolLeft>0)
		{
			sideStepCoolLeft -= Time.deltaTime;
		}

			/****************** ATTACK **************************************/
		if (!actionInProgress && Input.GetAxis(ATTACK_INPUT) > 0 && 
		     attackTimeLeft<=0 && attackCoolLeft <=0)
		{
			sideStepTimeLeft=0;

			playerAnimator.play(attackAnim, false, true);
			
			swordToEnable.GetComponent<DamagesEnemies>().attacking = true;

			// if not in Air, attackDirection = transform.forward?
			attackDirection =  faceDirection.rotation * Vector3.forward;
			
			attackTimeLeft = attackTime;
			attackCoolLeft = attackCoolDown;
			
			attacking = true;
			actionInProgress = true;
		}
		if (attacking)
		{
			if (attackTimeLeft>0)
			{
				this.GetComponent<CharacterController>().Move(attackDirection * (attackDistance/(attackTime/Time.deltaTime)));
				attackTimeLeft -= Time.deltaTime;
			}
			else
			{
				swordToEnable.GetComponent<DamagesEnemies>().attacking = false;
				attacking = false;
				actionInProgress = false;
			}
		}
		else if (attackCoolLeft>0)
		{
			attackCoolLeft -= Time.deltaTime;
		}
	}
}