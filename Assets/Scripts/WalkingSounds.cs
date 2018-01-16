using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSounds : MonoBehaviour {

    private Vector3 lastStepPosition;
    private float timeSinceLastStep;
    public float stepDistance;
    public AudioSource source;

    public SoundCollection walking;
    public SoundCollection running;
    public float runningThresholdSpeed;
    public AnimationCurve soundVolumeByTime;

	void Start () {
		lastStepPosition = transform.position;
        timeSinceLastStep = -1;
	}
	
	void Update () {
        float distance = ( transform.position - lastStepPosition ).magnitude;
        bool doStep = distance >= stepDistance;
        if( doStep ){

            //select a sound
            float elapsed = Time.time - timeSinceLastStep;
            float speed = distance / elapsed;

            AudioClip clip;
            float vol = soundVolumeByTime.Evaluate( elapsed );
            Debug.LogFormat("speed={0} vol={1} elapsed={2}",speed,vol,elapsed);
            //Debug.Log(speed);
            if( speed >= runningThresholdSpeed ){
				clip = running.GetRandom();
            } 
            else {
				clip = walking.GetRandom();

            }

            source.PlayOneShot( clip, vol );

            //set it's volume

            lastStepPosition = transform.position;

            timeSinceLastStep = Time.time;
        }
	}
}

