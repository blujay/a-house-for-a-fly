using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nightmarecube : MonoBehaviour {

    float cubeY;
    float audioChangeAmount;
    public int cubesNumber;
    public AudioSource cot;
    public AudioSource music;
    public AudioSource explosion;

    void Start() {
        
        music.Play();
        cot.volume = 1f;
        music.volume = 0.1f;
        audioChangeAmount = 1f / (cubesNumber);
    }


	
	// Update is called once per frame
	void Update () {

        //Current volume of audio source on cot
        float cotVol = cot.volume;
        float musicVol = music.volume;

        // establish y position of this cube
        cubeY = GetComponent<Transform>().position.y;

        //Debug.Log("Current vol: " + cotVol);

        if (cubeY > -20)
        {

            //Debug.Log("Above ground");

        }

        else
        {
            //Debug.Log("Below ground");
            cot.volume -= audioChangeAmount;
            music.volume += audioChangeAmount / 2;
            //Debug.Log("altered vol: " + cotVol);
            explosion.Play();
            Destroy(this.gameObject);
            //Debug.Log("killed");
        }


    }
}
