using UnityEngine;
using System.Collections;

public class BroomFollowScript : MonoBehaviour {

	private Rigidbody rigidBody;

	public GameObject curlingStone;
	public Vector3 curlingPos;
	public CurlingStoneScript curlingScript;
	public bool follow;
	public float distanceToStone;

	void Awake () {
		curlingStone = GameObject.Find ("CurlingStone");
		curlingScript = curlingStone.GetComponent<CurlingStoneScript> ();
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		curlingPos = curlingStone.transform.localPosition;
		if (follow) {
			//rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, curlingScript.speed);
			transform.localPosition = new Vector3 (curlingPos.x, curlingPos.y + distanceToStone, transform.localPosition.z);
		}
	}
}
