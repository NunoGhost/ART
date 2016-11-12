using UnityEngine;
using System.Collections;

public class BroomFollowScript : MonoBehaviour {

	private Rigidbody rigidBody;

	public GameObject curlingStone;
	public Vector3 curlingPos;
	public CurlingStoneScript curlingScript;

	void Awake () {
		curlingStone = GameObject.Find ("CurlingStone");
		curlingScript = curlingStone.GetComponent<CurlingStoneScript> ();
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		curlingPos = curlingStone.transform.position;
		if (curlingScript.fire) {
			rigidBody.velocity = new Vector3 (0, 0, curlingScript.speed);
		}
	}
}
