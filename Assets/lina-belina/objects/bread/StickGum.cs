using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickGum : MonoBehaviour {
    
    HouseEasy houseScript;
    public AudioSource gumAudioSource;
    public SoundCollection stickingBreadSounds;

    void Start() {
        
    }
	
	// Update is called once per frame
	void OnEnable()
    {
        stickingBreadSounds.Play(gumAudioSource);
        houseScript = FindObjectOfType<HouseEasy>();
        houseScript.CountBreadStick();
        Debug.Log("housescript added one to breadstick");
        Debug.Log("bricks stuck = " + houseScript.brickCount);
    }
}
