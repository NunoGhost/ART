using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OffBoundsScript : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		other.gameObject.SetActive (false);
		if(other.tag=="CurlingStone"){
			GameObject.Find ("OutOfBoundsText").GetComponent<Text> ().text = "OUT OF BOUNDS";
		}
	}
}
