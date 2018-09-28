using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickGum : MonoBehaviour {
    
    HouseScript houseScript;

    void Start() {
        
    }
	
	// Update is called once per frame
	void OnEnable()
    {
        houseScript = FindObjectOfType<HouseScript>();
        houseScript.CountBreadStick();
        Debug.Log("housescript added one to breadstick");
        Debug.Log("bricks stuck = " + houseScript.brickCount);
    }
}
