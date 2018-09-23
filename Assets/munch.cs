using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class munch : MonoBehaviour
{

    public GameObject PrefabGum;
    GameObject NewGum;
    AudioSource audioS;

    private void OnCollisionEnter(Collision other)
    {

        if (other.collider.name == "NewCrumb")

            audioS = GetComponent<AudioSource>();
            audioS.Play();
        {

            Debug.Log("Collided with: " + other.collider.name);

            var NewCube = other.collider.gameObject;
            var NewCubePosition = other.transform.position;
            //Debug.Log("CrumbPosition = " + NewCubePosition);

            //Debug.Log("Chowed on the crumb");
            Destroy(NewCube);
            NewGum = Instantiate(PrefabGum, NewCubePosition, Quaternion.identity) as GameObject;
        }
    }
}