using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWithFire : Enermy {

	public float secondsBeforeDead;
	private ParticleSystem fireEffect;
	private bool onFire = false;

	void start(){
		Debug.Log("Fire");
		//fireEffect = this.GetComponentInChildren<GameObject>();
		//fireEffect = this.GetComponentInChildren<ParticleSystem>();
		//Debug.Log(fireEffect);
		//fireEffect.SetActive(false);
	}

	public void Burned(){
		print ("enemy hit by bonerang");
		fireEffect = this.transform.Find ("Fire effect").GetComponent<ParticleSystem>();

		onFire = true;
		fireEffect.gameObject.SetActive(true);
		StartCoroutine(beforeDead());
	

	}

	IEnumerator beforeDead(){
		speed = 0;
		yield return new WaitForSeconds(secondsBeforeDead);
		Destroy (this.gameObject);
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Enermy")) {
			if ( this.onFire ) {
				EnemyWithFire enemy = collision.gameObject.GetComponentInParent<EnemyWithFire> ();
				enemy.Burned ();
			}
		}
	}
}
