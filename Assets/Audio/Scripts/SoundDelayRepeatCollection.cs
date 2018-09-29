using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ABertmark

public class SoundDelayRepeatCollection : MonoBehaviour 

{
	public AudioSource audioSource;
	private float lastPlay;
	public float firstTimeDelay;
	public float timeInbetweenSound;
	public SoundCollection soundCollection;

	void Start ()
	{
		StartCoroutine( PlayLoop() );
	}

	IEnumerator PlayLoop () 
	{
		yield return new WaitForSeconds(firstTimeDelay);
		soundCollection.Play(audioSource);
		while(true){
			yield return new WaitForSeconds(timeInbetweenSound);
			soundCollection.Play(audioSource);
		}
	}
}