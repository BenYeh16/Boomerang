using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyStraight : Enermy {

	private Vector3 dir;
	private float straightRange = 10;
	public float sqrdistance;

	// Use this for initialization
	public override void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		updateDirection ();
	}

	private void updateDirection(){
		this.transform.LookAt (target);
		dir = target.position - this.transform.position;
		dir.y = 0;
	}
	
	// Update is called once per frame
	public override void Update () {

		rigidbody.velocity = dir.normalized * speed;
		this.transform.LookAt (this.gameObject.transform.position + dir);
		sqrdistance = (this.transform.position - target.transform.position).sqrMagnitude;
		if (sqrdistance > straightRange * straightRange) {
			updateDirection ();
		}
//		float step = speed * Time.deltaTime;
//		this.transform.Translate ((target.position - this.transform.position).normalized * step, Space.World);
	}
}
