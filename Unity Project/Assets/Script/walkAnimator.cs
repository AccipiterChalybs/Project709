using UnityEngine;
using System.Collections;

public class walkAnimator : MonoBehaviour {

	public AnimationClip walkAnimation;

	private Animation animPlayer;

	// Use this for initialization
	void Start () {
		animPlayer = this.GetComponent<Animation> ();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!animPlayer.isPlaying) 
		{
			animPlayer.CrossFade (walkAnimation.name);
		}
	}
}
