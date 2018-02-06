using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioClipOnTriggerSimple : MonoBehaviour {

	public AudioClip[] ClipToPlay;
    public AudioSource source;
	public string GameTag;
	bool played = false;
		

	void playSound(){
		source.clip = ClipToPlay [Random.Range (0, ClipToPlay.Length)];
		
			source.Play ();
			
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == GameTag) {
			playSound();
			//Debug.Log ("collided with " + GameTag);
		}
	}

    void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == GameTag) {
            source.Stop();
        }
	}

}