using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayOnKeyComponent : MonoBehaviour 
	{

	public AudioClip[] footsteps;
	private int foot;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frames
	void Update () {
		if(Input.GetButtonUp("Jump"))
			{
	
			Debug.Log("Jump input detected!");
			foot = Mathf.FloorToInt(Random.Range(0, footsteps.Length));
				GetComponent<AudioSource>().PlayOneShot( footsteps[foot] );

		}
		
	}
}
