using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public const string ATTACK_INPUT = "Fire1";

	public AnimationClip attackAnim;

	public Transform faceDirection;

	public GameObject swordToEnable;

	public float attackDistance = 10f;
	public float attackTime = 0.2f;
	public float attackCoolDown = 1.2f;
	private float attackTimeLeft;
	private float attackCoolLeft;
	private Vector3 attackDirection;

	private bool attacking;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetAxis(ATTACK_INPUT) > 0 && attackTimeLeft<=0 && attackCoolLeft <=0)
		{
			this.GetComponent<PlayerAnimator>().play(attackAnim, false, true);

			swordToEnable.GetComponent<DamagesEnemies>().attacking = true;

			attackDirection =  transform.forward;

			attackTimeLeft = attackTime;
			attackCoolLeft = attackCoolDown;

			attacking = true;
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
			}
		}
		else if (attackCoolLeft>0)
		{
			attackCoolLeft -= Time.deltaTime;
		}
	
	}
}
