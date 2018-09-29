using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ABertmark

public class SoundDelayRepeat : MonoBehaviour 
{
	private AudioSource audioSource;
	public AudioClip audioClip;
	private float lastPlay;
	public float firstTimeDelay;
	public float timeInbetweenSound;

	public float volumeMinValue=1;
	public float volumeMaxValue=1;
	public float pitchMinValue=1;
	public float pitchMaxValue=1;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
		StartCoroutine( PlayLoop() );
	}

	IEnumerator PlayLoop () 
	{
		yield return new WaitForSeconds(firstTimeDelay);
		audioSource.volume = Random.Range(volumeMinValue, volumeMaxValue);
		audioSource.pitch = Random.Range(pitchMinValue, pitchMaxValue);
		audioSource.Play();
		while(true){
			yield return new WaitForSeconds(timeInbetweenSound);
			audioSource.volume = Random.Range(volumeMinValue, volumeMaxValue);
			audioSource.pitch = Random.Range(pitchMinValue, pitchMaxValue);
			audioSource.Play();
		}
	}
}