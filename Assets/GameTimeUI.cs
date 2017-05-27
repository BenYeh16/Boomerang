using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeUI : MonoBehaviour {

	public Text timerText;
	private float timer;
	private bool isPlaying;

	// Use this for initialization
	void Start () {
		timer = 0;
		isPlaying = true;
	}

	// Update is called once per frame
	void Update () {
		if (isPlaying) {
			timer += Time.deltaTime;
			updateTimerText();
		}
	}

	public void Reset(){
		timer = 0;
		updateTimerText();
	}

	public void Stop(){
		isPlaying = false;
	}

	public void Play(){
		isPlaying = true;
	}

	private void updateTimerText(){
		timerText.text = timer.ToString ("###0");
	}
}
