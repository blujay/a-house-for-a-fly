using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

public class TransitionToSnapshotsOnPlayerEntry : MonoBehaviour {

	public List<AudioMixerSnapshot> Snapshots;
	public float OverTime;
	
	void OnTriggerEnter(Collider other)
	{
		if(!other.CompareTag ("Player")) return;
		Debug.Log ("Player in room");
		foreach(var snapshot in Snapshots)
			snapshot.TransitionTo(OverTime);
	}
}
