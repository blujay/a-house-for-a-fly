using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenStory : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip chickenStoryClip;
    bool played = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("play sound now");
            playSound();
        }
    }

    void playSound()
    {
        if (!played)
        {
            audioS.PlayOneShot(chickenStoryClip);
            played = true;
        }
        else
        {
            played = false;
        }

    }
}