using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {
	
	public AnimationClip idleAnimation;
	public AnimationClip walkForwardsAnimation;
	public AnimationClip walkSideAnimation;

	public Transform player;

	private Animation animationPlayer;

	private bool blockingAnimPlaying=false;

	// Use this for initialization
	void Start () {
		animationPlayer = player.GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!animationPlayer.isPlaying || !blockingAnimPlaying) {
						int rotation = -1;
						if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
								rotation = 0;
								if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
										rotation = -45;
								}
								if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
										rotation = 45;
								}
						}
						if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
								rotation = 180;
								if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
										rotation = -135;
								}
								if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
										rotation = 135;
								}
						}
						if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
								rotation = -90;
						}
						if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
								rotation = 90;
						}
						switch (rotation) {
						case 0:
								this.play (walkForwardsAnimation, false, false);
								break;
						case 45:
								this.play (walkForwardsAnimation, false, false);
								break;
						case 90:
								this.play (walkSideAnimation, false, false);
								break;
						case 135:
								this.play (walkForwardsAnimation, true, false);
								break;
						case 180:
								this.play (walkForwardsAnimation, true, false);
								break;
						case -135:
								this.play (walkForwardsAnimation, true, false);
								break;
						case -90:
								this.play (walkSideAnimation, true, false);
								break;
						case -45:
								this.play (walkForwardsAnimation, false, false);
								break;
						case -1:
								animationPlayer.Stop ();
								break;
						}
				}
	}

	public void play(AnimationClip clip, bool reverse, bool block)
	{
		blockingAnimPlaying = block;
		if (!animationPlayer.IsPlaying(clip.name))
		{
			if (reverse) 
			{
				animationPlayer [clip.name].speed = -1.0f;
				animationPlayer [clip.name].time = animationPlayer [clip.name].length;
			}
			else
			{
				animationPlayer [clip.name].speed = 1.0f;
				animationPlayer [clip.name].time = 0;
			}
		}
		animationPlayer.CrossFade(clip.name);
	}
}
