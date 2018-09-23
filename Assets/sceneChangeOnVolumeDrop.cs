using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneChangeOnVolumeDrop : MonoBehaviour {

    public AudioSource cot;
    public SteamVR_LoadLevel load;

    // Use this for initialization

    void Start() {

        load.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        float cotVol = cot.volume;
        Debug.Log("cot vol = " + cotVol);

        if (cotVol < 0.05f) {

            load.enabled = true;

        }

	}
}
