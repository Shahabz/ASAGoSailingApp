﻿using UnityEngine;
using System.Collections;

public class NavBoatControl : MonoBehaviour {

	Rigidbody body;
	float currThrust;
	public enum BoatSideFacingWind {Port, Starboard};
	Vector3 directionWindComingFrom = new Vector3(0f,0f,1f);
	float angleToAdjustTo;
	float angleWRTWind;
	Vector3 boatDirection;
	bool isJibing;
	float smoothRate = 1f;
	float turnStrength = 100f;
	

	void Start () {
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//figure out angular relation ship between boat and wind
		Vector3 localTarget = transform.InverseTransformPoint(directionWindComingFrom);
		//isNegative lets us know port vs starboard
		float isNegative = Mathf.Atan2(localTarget.x, localTarget.z)/Mathf.Abs(Mathf.Atan2(localTarget.x, localTarget.z));
		boatDirection = transform.forward;
		angleWRTWind = Vector3.Angle(boatDirection,directionWindComingFrom) * isNegative;
		if (float.IsNaN(angleWRTWind)) {
			angleWRTWind=0;
		}

		if(Input.GetKey(KeyCode.LeftArrow)) {
			body.AddRelativeTorque (-Vector3.up*turnStrength);

		}

		if(Input.GetKey(KeyCode.RightArrow)) {
			body.AddRelativeTorque (Vector3.up*turnStrength);

		}

	}

	void FixedUpdate () {
		//make thrust proportionate to dist WRT to wind
		body.AddForce (transform.forward * ReturnCurrentThrust());
		Debug.DrawRay(transform.position, transform.forward,Color.white);
	}

	float ReturnCurrentThrust() {
		return 1000f;
	}
}
