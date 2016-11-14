using UnityEngine;
using System.Collections;

public class CurlingStoneScript : MonoBehaviour {

	private Rigidbody rigidBody;
	private GameObject buttonMarker;
	public Vector3 velocity;
	public Vector3 oldRotation;

	public float speed;
	public float friction;
	public bool fire = false;
	public bool stopped = false;
	public bool positiveSpeedStart;
	public bool positiveSpeedNow;

	// Use this for initialization
	void Awake () {
		rigidBody = GetComponent<Rigidbody> ();
		buttonMarker = GameObject.Find ("ButtonMarker");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			fire = true;
			//rigidBody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
			transform.FindChild ("Arrow").gameObject.SetActive (false);
			oldRotation = gameObject.transform.localEulerAngles;
			rigidBody.constraints = RigidbodyConstraints.FreezePositionY;
			rigidBody.AddRelativeForce( new Vector3 (0, speed, 0));
			if (rigidBody.velocity.z > 0) {
				positiveSpeedStart = true;
			} else {
				positiveSpeedStart = false;
			}
		}
	}

	void FixedUpdate(){
		if (fire) {
			Move ();
		}

		if (!fire) {
			gameObject.transform.localEulerAngles = new Vector3 (0, 0, buttonMarker.transform.localEulerAngles.z);
		}
		velocity = rigidBody.velocity;
	}

	void Move(){
		
		gameObject.transform.localEulerAngles = oldRotation;
		rigidBody.AddRelativeForce (new Vector3 (0, -friction, 0));
		if (rigidBody.velocity.z > 0) {
			positiveSpeedNow = true;
		} else {
			positiveSpeedNow = false;
		}
		if(positiveSpeedStart != positiveSpeedNow){
			fire = false;
			rigidBody.constraints = RigidbodyConstraints.FreezePosition;
			stopped = true;
		}
	}
}
