
using UnityEngine;
using System.Collections;
using VRTK;


public class Knob_Grab_Sound : MonoBehaviour {

	public AudioSource soundEmitter;
	public SoundCollection collection;

    private VRTK_InteractableObject interactable;

    void Start() {

        interactable = GetComponent<VRTK_InteractableObject> ();
		interactable.InteractableObjectGrabbed += OnObjectGrabbed;
	}
		

	void OnObjectGrabbed(object obj,InteractableObjectEventArgs args){

		AudioClip clip  = collection.GetRandom ();

        soundEmitter.PlayOneShot (clip);

    }

}

