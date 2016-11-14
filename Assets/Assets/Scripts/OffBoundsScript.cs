using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OffBoundsScript : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Debug.Log (other);
		other.gameObject.SetActive (false);
		if(other.tag=="CurlingStone"){
			GameObject.Find ("OutOfBoundsText").GetComponent<Text> ().fontSize = 36;
			GameObject.Find ("OutOfBoundsText").GetComponent<Text> ().text = "OUT";
			StartCoroutine ("BiggerLetters");
		}
	}

	IEnumerator BiggerLetters(){
		float timer = 0;
		while (timer < 0.5f) {
			timer += Time.deltaTime;
			yield return null;
		}
		GameObject.Find ("OutOfBoundsText").GetComponent<Text> ().fontSize = 46;
		GameObject.Find ("OutOfBoundsText").GetComponent<Text> ().text = "OUT OF";
		StartCoroutine ("BiggerLetters2");
		yield return null;
	}

	IEnumerator BiggerLetters2(){
		float timer = 0;
		while (timer < 0.5f) {
			timer += Time.deltaTime;
			yield return null;
		}
		GameObject.Find ("OutOfBoundsText").GetComponent<Text> ().fontSize = 56;
		GameObject.Find ("OutOfBoundsText").GetComponent<Text> ().text = "OUT OF BOUNDS";
		yield return null;
	}
}
