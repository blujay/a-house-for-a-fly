
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LoopingSoundComponent : MonoBehaviour {
	

	public SimpleAudioEvent footsteps;
	int foot;
	AudioSource audioSource;


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update () {
		if (audioSource.isPlaying == false) {
			footsteps.Play(audioSource);
		}
	}
}
