using UnityEngine;
using System.Collections;

public class CurlingStoneScript : MonoBehaviour {

	private Rigidbody rigidBody;
	private GameObject buttonMarker;
	public Vector3 velocity;

	public float speed;
	public float friction;
	public bool fire = false;
	public bool stopped = false;

	// Use this for initialization
	void Awake () {
		rigidBody = GetComponent<Rigidbody> ();
		buttonMarker = GameObject.Find ("ButtonMarker");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			fire = true;	
			rigidBody.AddRelativeForce( new Vector3 (0, speed, 0));
		}
	}

	void FixedUpdate(){
		if (fire) {
			Move ();
		}

		if (!fire) {
			gameObject.transform.localEulerAngles = new Vector3 (0, 0, buttonMarker.transform.localEulerAngles.z);
		}
	}

	void Move(){
		velocity = rigidBody.velocity;
		rigidBody.AddRelativeForce (new Vector3 (0, -friction, 0));
		speed -= 0.00001f;
		if (speed <= 0) {
			fire = false;
			stopped = true;
		}
	}
}
