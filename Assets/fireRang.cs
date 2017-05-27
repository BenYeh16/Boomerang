using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireRang : MonoBehaviour {

	public Follower follower;
	public ScoreUIMgr scoreUIMgr;

	private int hit_counter;
	private GameObject last_hit_obj = null;

	// Use this for initialization
	void Start () {
		hit_counter = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	public void FlyBack(){
		last_hit_obj = null;
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Enermy")) {
			EnemyWithFire enemy = collision.gameObject.GetComponentInParent<EnemyWithFire> ();
			enemy.Burned ();
			if (follower.state == Follower.State.Drop) {
				Debug.Log("s");
				if (last_hit_obj == null || last_hit_obj != collision.gameObject) {
					last_hit_obj = collision.gameObject;
					hit_counter++;
					print (this.gameObject.name + " bonerang hit: counter = " + hit_counter + ", multiplier = " + enemy.reward_mutiplier+", isFlyBack = "+(follower.state == Follower.State.flyBack));
					int addScore = hit_counter * enemy.reward_mutiplier;
					if (follower.state == Follower.State.flyBack) {
						addScore += 1;
					}
					//scoreUIMgr.AddScoreUI (addScore);

				}
				enemy.Burned ();
			}
		}
		else if (collision.gameObject.CompareTag ("Player")) {
			if (last_hit_obj == null || last_hit_obj != collision.gameObject) {
				if (follower.state == Follower.State.flyBack || follower.state == Follower.State.Drop) {
					last_hit_obj = collision.gameObject;
					collision.gameObject.GetComponent<Player> ().CatchBoomerang ();
					Destroy (this.gameObject);
				}
			}
		}
	}
}
