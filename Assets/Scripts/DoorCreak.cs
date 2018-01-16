using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCreak : MonoBehaviour {
    public SoundCollection OpenSound;
    public SoundCollection CloseSound;
    public bool isPositiveRotationOpeningDoor = true;
    public Transform targetDoor;
    public AudioSource audioSource;
    public float maxRotation = 90f;
    public float minVolSpeed = 0.1f;
    public float maxVolSpeed = 1;
    private float lastRotationSpeed;
    [Range(0,1)]
    public float rotationSpeedSmoothing;
    private Quaternion lastRotation;
    private bool wasOpening;
    private float initialDoorAngle;
    private bool stopped;


	void Start ()
    {
        initialDoorAngle = targetDoor.rotation.eulerAngles.y;
        lastRotation = targetDoor.rotation;
        stopped = true;
    }
	
	void Update ()
    {
        float doorAngle = targetDoor.rotation.eulerAngles.y;
        float doorPosition = Mathf.Abs( RotationFix(doorAngle - initialDoorAngle) )/ maxRotation;
        float rotationDelta = RotationFix( doorAngle - lastRotation.eulerAngles.y );
        float rotationSpeed = Mathf.Abs((rotationDelta / maxRotation) / Time.deltaTime);

        rotationSpeed = lastRotationSpeed + rotationSpeedSmoothing * (rotationSpeed - lastRotationSpeed);
        lastRotationSpeed = rotationSpeed;

        if (rotationSpeed > 0.001)
        {
            bool isOpening = (rotationDelta > 0) != isPositiveRotationOpeningDoor;
            if (!isOpening)
            {
                doorPosition = 1f - Mathf.Clamp01(doorPosition);
            }
            AudioClip clip = isOpening ? OpenSound.GetRandom() : CloseSound.GetRandom();
            float playHeadDestinationTime = doorPosition * clip.length;

            if (stopped || (isOpening != wasOpening)) {
                audioSource.clip = clip;
                audioSource.time = playHeadDestinationTime;
                audioSource.Play();

                stopped = false;
            }



            Debug.LogFormat("isOpening={0} playbackSpeed={1}", isOpening, rotationSpeed);


            audioSource.volume = Mathf.Clamp01(Mathf.InverseLerp(minVolSpeed, maxVolSpeed, rotationSpeed));

            wasOpening = isOpening;
        }
        else
        {
            audioSource.Stop();
            stopped = true;
        }

        lastRotation = targetDoor.rotation;	
	}

    private float RotationFix(float rotation) {
        if (rotation > 180) rotation -= 360;
        if (rotation < -180) rotation += 360;
        return rotation; 
    }

}
