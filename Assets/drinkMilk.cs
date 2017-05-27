using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkMilk : MonoBehaviour {

	public BloodMgr mgr;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Player")) {
			mgr.bloodGain();
			// maybe add attack animation
		}
	}
}
