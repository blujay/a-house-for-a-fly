using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundWhileOnCollision : MonoBehaviour {
    public GameObject nightmare;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = nightmare.GetComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "nightmarecube") {
            audioSource.Play();
        }

    }

    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "nightmarecube")
        {
            audioSource.Play();
        }
        
    }

    void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "nightmarecube")
        {
            audioSource.Stop();
        }

    }
}