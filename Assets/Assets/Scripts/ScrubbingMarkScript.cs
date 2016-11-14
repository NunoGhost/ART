using UnityEngine;
using System.Collections;

public class ScrubbingMarkScript : MonoBehaviour {

	public bool left;
	
	void OnTriggerExit(Collider other){
		if (other.tag == "CurlingStone") {
			left = true;
			GameObject.FindGameObjectWithTag ("Broom").GetComponent<BroomFollowScript> ().follow = true;
			GameObject.FindGameObjectWithTag ("Broom").SetActive(true);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Broom") {
			GameObject.FindGameObjectWithTag ("Broom").GetComponent<BroomFollowScript> ().follow = false;
		}
	}
}
