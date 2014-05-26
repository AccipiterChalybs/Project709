using UnityEngine;
using System.Collections;


public class EnemyChase : MonoBehaviour {
	
	private Transform target;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindWithTag ("Player").transform;	
		agent = this.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (agent.enabled)
		{
			agent.destination = target.position;
		}
	}
}
