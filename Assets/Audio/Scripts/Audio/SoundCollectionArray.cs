using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundCollectionArray : MonoBehaviour {

	public AudioClip[] footsteps;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Jump"))
			{
			
				Debug.Log("Jump input detected!");
			GetComponent<AudioSource>().Play();

			}

	


			}

			}
	
