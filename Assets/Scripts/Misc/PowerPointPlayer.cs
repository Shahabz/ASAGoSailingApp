﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerPointPlayer : MonoBehaviour {

	//must assign equal length to all of these in inspector
	public int numberOfSlides;
	public AudioSource[] soundFiles;
	public GameObject[] textObjects;
	public GameObject[] gameObjects;
	public float[] timeDelayUntilNextSlide;

	float timer;

	int currentIndex;
	[SerializeField]
	bool isPlaying;

	/// <summary>
	/// Use this to trigger what happens after the powerpoint
	/// </summary>
	public bool powerPointHasFinished;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlaying) {
			if (timer < timeDelayUntilNextSlide [currentIndex]) {
				timer += Time.deltaTime;
			} else {
				GotoNextSlide ();
			}
		}
	}

	void StartPowerPoint () {
		isPlaying = true;
		textObjects [currentIndex].SetActive (true);
		gameObjects [currentIndex].SetActive (true);

	}

	void ActivateThisSlide() {
		if (textObjects [currentIndex] != null) {
			textObjects [currentIndex].SetActive (true);
		}
		if (gameObjects [currentIndex] != null) {
			gameObjects [currentIndex].SetActive (true);
		}
		if (soundFiles [currentIndex] != null) {
			soundFiles [currentIndex].Play ();
		}

	}
	void DeactivateLastSlide() {
		if (textObjects [currentIndex] != null) {
			textObjects [currentIndex].SetActive (false);

		}
		if (gameObjects [currentIndex] != null) {
			gameObjects [currentIndex].SetActive (false);
		}

	}

	void GotoNextSlide() {
		timer = 0;

		DeactivateLastSlide ();
		if (currentIndex == numberOfSlides - 1) {
			FinishPowerPoint ();
			return;
		}
		currentIndex++;
		ActivateThisSlide ();
	}

	void FinishPowerPoint() {
		powerPointHasFinished = true;
		isPlaying = false;
	}
}
