
using UnityEngine;
using System.Collections;

public class DoorCreakTest : MonoBehaviour {

	public AudioClip[] creak;
	public float creakAng = 2; // creak each creakAng
	public AudioSource doorHinge;

	public float pitchControl = 0.1f; // control pitch sensitivity
	private float angle = 0;
	private float lastAngle = 0;
	private float lastCreak = 0;



	void Start(){
		doorHinge = GetComponent<AudioSource> () as AudioSource;

	}

	void Update () {
		angle = transform.eulerAngles.y;
		//print("Angle: " + angle);
		if (Mathf.Abs(angle - lastAngle) > creakAng){
			lastAngle = angle; // update lastAngle
			float timeDelta = Time.time - lastCreak; // calc time from last creak
			float pitchChange = timeDelta * 8;
			//print("timeDelta: " + timeDelta);
			//print("pitchChange: " + pitchChange);
			lastCreak = Time.time;
			//print("lastCreak: " + lastCreak);
			// increase pitch somewhat according to speed:
			doorHinge.pitch = Mathf.Clamp(pitchChange, 1.0f, 3.5f);
			//print("doorHinge.pitch: " + doorHinge.pitch);
			// play a randomly selected creak sound:
			doorHinge.PlayOneShot(creak[Random.Range(0, creak.Length)]);
		}
	}
}