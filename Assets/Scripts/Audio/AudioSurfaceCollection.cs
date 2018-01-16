using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AudioSurfaceCollection : ScriptableObject {

	public AudioSurface[] surfaceCollection;

	public void Play (string tag, AudioSource source)
	{
		Debug.Log ("Playing");
		foreach (AudioSurface surface in surfaceCollection) {
		
			if (surface.tag == tag)
			{
				source.outputAudioMixerGroup = surface.group;
				surface.audio.Play (source);
			}
		}

	}

}
	