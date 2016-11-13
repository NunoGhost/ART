﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MarkerManagerScript : MonoBehaviour
{

	private Rigidbody broomRigidBody;

	public AROrigin arOriginScript;
	public GameObject ringMarker;
	public GameObject broomMarker;
	public GameObject broom;
	public CurlingStoneScript curlingScript;

	public Vector3 lastBroomMarkerPosition;
	public Vector3 currentBroomMarkerPosition;
	public float broomSpeed;


	public RingScript redRingScript;
	public RingScript whiteRingScript;
	public RingScript blueRingScript;
	public bool insideRed;
	public bool insideWhite;
	public bool insideBlue;
	public bool checkForScore;
	public float score;
	public bool front;

	public Vector3 originalBroomPosition;
	public Vector3 currentBroomPosition;
	public Vector3 broomVelocity;

	public Text scoreText;

	void Awake ()
	{
		arOriginScript = GameObject.Find ("Scene root").GetComponent<AROrigin> ();
		ringMarker = GameObject.Find ("RingMarker");
		broomMarker = GameObject.Find ("BroomMarker");
		broom = GameObject.FindGameObjectWithTag ("Broom");
		lastBroomMarkerPosition = broomMarker.transform.position;
		curlingScript = GameObject.Find ("CurlingStone").GetComponent<CurlingStoneScript> ();
		redRingScript = GameObject.Find ("InnerRing").GetComponent<RingScript> ();
		whiteRingScript = GameObject.Find ("MiddleRing").GetComponent<RingScript> ();
		blueRingScript = GameObject.Find ("OuterRing").GetComponent<RingScript> ();
		broomRigidBody = broom.GetComponent<Rigidbody> ();
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
	}

	void FixedUpdate ()
	{

		//Ensure RingMarker is always the base marker
		if (ringMarker.activeSelf) {
			arOriginScript.SetBaseMarker (ringMarker.GetComponent<ARTrackedObject> ().GetMarker ());
		}

		if (!curlingScript.fire) {
			originalBroomPosition = broom.transform.position;
		}

		currentBroomMarkerPosition = broomMarker.transform.position;
		//Check if a significant movement on the tracker was registered
		if (Mathf.Abs (lastBroomMarkerPosition.x - currentBroomMarkerPosition.x) > 0.01 && curlingScript.fire) {
			if (front) {
				broomRigidBody.velocity = new Vector3 (-broomSpeed, broomRigidBody.velocity.y, broomRigidBody.velocity.z);
			} else {
				broomRigidBody.velocity = new Vector3 (broomSpeed, broomRigidBody.velocity.y, broomRigidBody.velocity.z);
			}

			if (curlingScript.fire) {
				curlingScript.speed += 0.001f;
			}

		} else {
			broomRigidBody.velocity = new Vector3 (0, broomRigidBody.velocity.y, broomRigidBody.velocity.z);
		}

		if (broom.transform.position.x <= originalBroomPosition.x - 0.002f) {
			front = false;
		}
		if (broom.transform.position.x >= originalBroomPosition.x + 0.002f) {
			front = true;
		}

		lastBroomMarkerPosition = currentBroomMarkerPosition;
		currentBroomPosition = broom.transform.position;
		broomVelocity = broomRigidBody.velocity;

		if (curlingScript.stopped && checkForScore) {
			checkForScore = false;
			if (redRingScript.inside) {
				Debug.Log ("Red points");
				score = 200.0f;
			} else if (whiteRingScript.inside) {
				Debug.Log ("White points");
				score = 100.0f;
			} else {
				Debug.Log ("Blue points");
				score = 50.0f;
			}
		}

		scoreText.text = "Score: " + score;
	}
}
