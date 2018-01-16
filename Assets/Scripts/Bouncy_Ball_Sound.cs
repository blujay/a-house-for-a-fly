using UnityEngine;
using System.Collections;

public class Bouncy_Ball_Sound : MonoBehaviour {

	public AudioClip bounceHard;
	public AudioClip bounceMedium;
	public AudioClip bounceLight;
	public AudioClip bounceRoll;


	//make Roll into loop and make into Grounded thing in new script//
	//for hits, make the if statement first and give overlapping values for velocity for each collection, then apply randomisation for those//

	[System.Serializable]
	public class SoundCollection {
		public AudioClip[] clips;

		int index;

		public AudioClip GetRandom(){
			index = ( Random.Range (1, clips.Length - 1) + index ) % clips.Length;
			return clips[ index ];
		}

		public AudioClip GetNext(){

			int i = index;
			index++;
			if( index >= clips.Length )
				index = 0;
			return clips[i];
		}
	}


	public AudioSource source;
	public float lowPitchRange = .75F;
	public float highPitchRange = 1.5F;
	public float velToVol = .2F;
	public float velocityClipSplit = 10F;


	void Awake () {

		source = GetComponent<AudioSource>();
	}


	void OnCollisionEnter (Collision coll)
	{
		source.pitch = Random.Range (lowPitchRange,highPitchRange);
		float hitVol = coll.relativeVelocity.magnitude * velToVol;
		if (coll.relativeVelocity.magnitude < velocityClipSplit)
			source.PlayOneShot(bounceLight,hitVol);
		else 
			source.PlayOneShot(bounceHard,hitVol);

		if (GetComponent<Rigidbody>().velocity.magnitude < 0.01 ){
			//The Ball is not rolling
		}else{
			//The Ball is rolling
		}
	}

}