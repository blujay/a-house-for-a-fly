using UnityEngine;
using System.Collections;

public class FootstepHandler_ : MonoBehaviour {


	public AudioSource audioSource;
	public LayerMask footFallSoundsLayerMask;
	public SurfaceToSoundCollection footstepCollection;


	void  OnFootstep (){
		if (!audioSource.enabled)			
		{
			return;
		}
			
		RaycastHit hit;
		if (!Physics.Raycast (transform.position + Vector3.up, -Vector3.up, out hit, 1.5f, footFallSoundsLayerMask)) {
			return;
		}


		footstepCollection.Play (hit.collider.sharedMaterial, audioSource);

		//Debug.LogFormat ("{1} Mat={0}", hit.collider.sharedMaterial, name);

	}

}