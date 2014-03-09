using UnityEngine;
using System.Collections;


public class EnemyChase : MonoBehaviour {
	
	private Transform target;

	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindWithTag ("Player").transform;		
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.GetComponent<NavMeshAgent> ().destination = target.position;	
	}
}
