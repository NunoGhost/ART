using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MarkerManagerScript : MonoBehaviour {

	public AROrigin arOriginScript;
	public GameObject ringMarker;
	public GameObject broomMarker;
	public GameObject broom;
	public CurlingStoneScript curlingScript;

	public Vector3 lastBroomPosition;
	public Vector3 currentBroomPosition;
	public float broomSpeed;


	public RingScript redRingScript;
	public RingScript whiteRingScript;
	public RingScript blueRingScript;
	public bool insideRed;
	public bool insideWhite;
	public bool insideBlue;
	public bool checkForScore = true;
	public float score;

	void Awake(){
		arOriginScript = GameObject.Find ("Scene root").GetComponent<AROrigin> ();
		ringMarker = GameObject.Find ("RingMarker");
		broomMarker = GameObject.Find ("BroomMarker");
		broom = GameObject.Find ("Broom");
		lastBroomPosition = broomMarker.transform.position;
		curlingScript = GameObject.Find ("CurlingStone").GetComponent<CurlingStoneScript> ();
		redRingScript = GameObject.Find ("InnerRing").GetComponent<RingScript> ();
		whiteRingScript = GameObject.Find ("MiddleRing").GetComponent<RingScript> ();
		blueRingScript = GameObject.Find ("OuterRing").GetComponent<RingScript> ();

	}

	void Update(){

		//Ensure RingMarker is always the base marker
		if (ringMarker.activeSelf) {
			arOriginScript.SetBaseMarker(ringMarker.GetComponent<ARTrackedObject> ().GetMarker ());
		}

		currentBroomPosition = broomMarker.transform.position;
		//Check if a significant movement on the tracker was registered
		if (Mathf.Abs (lastBroomPosition.x - currentBroomPosition.x) > 0.02) {
			//Check direction of the movement on the X axis
			if (currentBroomPosition.x > lastBroomPosition.x) {
				broom.transform.position = new Vector3 (broom.transform.position.x + broomSpeed, broom.transform.position.y, broom.transform.position.z);
			} else {
				broom.transform.position = new Vector3 (broom.transform.position.x - broomSpeed, broom.transform.position.y, broom.transform.position.z);
			}

			if (curlingScript.fire) {
				curlingScript.speed += 0.001f;
			}
		}
		lastBroomPosition = currentBroomPosition;

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
	}
}
