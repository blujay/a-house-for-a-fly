using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundOnCollision : MonoBehaviour
{
    AudioSource myaudio;
    void Start()
    {
        myaudio = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "playsound")
        {
            myaudio.Play();
            Debug.Log("How do you enjoy the sound?");
        }
    }
}