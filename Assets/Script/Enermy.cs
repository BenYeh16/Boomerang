using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour {

	public enum EnermyType{chase, archer};

	public float speed;
	public Transform target;
	public EnermyType type = EnermyType.chase;
	public float timeBeforeDeath;

	public int damage = 1;

	public int reward_mutiplier = 1;

	private bool freezeFlag = false;
	private bool moveFlag = false;
	private Vector3 farAway = new Vector3(0, 100, 0);
	private Vector3 notFarAway = new Vector3(0, -100, 0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(type == EnermyType.chase && !freezeFlag){
			float step = speed * Time.deltaTime;
			this.transform.LookAt (target);
			this.transform.Translate ((target.position - this.transform.position).normalized * step, Space.World);
		}
	}

	public void Hit(int count){
		print ("enemy hit by bonerang");
		Freeze();
		InvokeRepeating("Blink", 0, 0.1f);
		Destroy (this.gameObject, timeBeforeDeath);
	}

	private void Freeze(){
		this.freezeFlag = true;
	}

	private void Blink(){
		/*if ( !moveFlag ) {
			this.transform.Translate(farAway);
			moveFlag = true;
		} else {
			this.transform.Translate(notFarAway);
			moveFlag = false;
		}*/
		Renderer material = this.GetComponent<Renderer>();
		if ( material.enabled == true ) {
			material.enabled = false;
		} else {
			material.enabled = true;
		}

	}


	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Player")) {
			Player player = collision.gameObject.GetComponent<Player> ();
			player.Hit (damage);
			print ("enemy hit player");
			// maybe add attack animation
		}
	}
}
