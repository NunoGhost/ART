using UnityEngine;
using System.Collections;

public class RingScript : MonoBehaviour {

	private SphereCollider collider;
	public bool inside;

	// Use this for initialization
	void Awake () {
		collider = GetComponent<SphereCollider> ();
	}
	
	void OnTriggerEnter(Collider other){
		if(other.name == ("CurlingStone")){
			inside = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.name == ("CurlingStone")){
			inside = false;
		}
	}
}
