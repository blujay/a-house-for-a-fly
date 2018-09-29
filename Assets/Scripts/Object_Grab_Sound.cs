
using UnityEngine;
using System.Collections;
using VRTK;


public class Object_Grab_Sound : MonoBehaviour {

	public AudioSource soundEmitter;
	public SoundCollection grabSoundCollection;
	public SoundCollection dropSoundCollection;
    

    private VRTK_InteractableObject interactable;


    void Start() {

        interactable = GetComponent<VRTK_InteractableObject> ();
		interactable.InteractableObjectGrabbed += OnObjectGrabbed;
        interactable.InteractableObjectUngrabbed += OnObjectDropped;
    }
		

	void OnObjectGrabbed(object obj,InteractableObjectEventArgs args){

		grabSoundCollection.Play (soundEmitter);

    }

	void OnObjectDropped(object obj,InteractableObjectEventArgs args){

		dropSoundCollection.Play (soundEmitter);
	}
}

