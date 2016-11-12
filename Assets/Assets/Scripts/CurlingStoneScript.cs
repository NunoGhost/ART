using UnityEngine;
using System.Collections;

public class CurlingStoneScript : MonoBehaviour {

	private Rigidbody rigidBody;

	public float speed;
	public bool fire = false;
	public bool stopped = false;

	// Use this for initialization
	void Awake () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			fire = true;	
		}
	}

	void FixedUpdate(){
		if (fire) {
			Move ();
		}
	}

	void Move(){
		rigidBody.velocity = new Vector3 (0, 0, speed);
		speed -= 0.00001f;
		if (speed <= 0) {
			fire = false;
			stopped = true;
		}
	}
}
