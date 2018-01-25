
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

		AudioClip clip  = grabSoundCollection.GetRandom ();
        soundEmitter.volume = Random.Range(0.8f, 1);
        soundEmitter.pitch = Random.Range(0.8f, 1);
        soundEmitter.PlayOneShot (clip);

    }

	void OnObjectDropped(object obj,InteractableObjectEventArgs args){

		AudioClip clip = dropSoundCollection.GetRandom ();
        soundEmitter.volume = Random.Range(0.8f, 1);
        soundEmitter.pitch = Random.Range(0.8f, 1);
		soundEmitter.PlayOneShot (clip);

	}
}

