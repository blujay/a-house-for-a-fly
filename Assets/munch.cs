using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class munch : MonoBehaviour
{

    public GameObject PrefabGum;
    public Transform handAttach;
    public AudioSource audioS;
    GameObject NewGum;
    GameObject NewCube;

    IEnumerator DestroySelf()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        NewCube.GetComponent<Rigidbody>().isKinematic = false;
        Destroy(NewCube.gameObject);
        print(Time.time);
    }
   

    private void OnCollisionEnter(Collision other)
    {

        if (other.collider.name == "NewCrumb")
            
        {

            Debug.Log("Collided with: " + other.collider.name);

            NewCube = other.collider.gameObject;
            NewCube.name = "Crumb";
            var NewCubePosition = other.transform.position;
            //Debug.Log("CrumbPosition = " + NewCubePosition);

            //Debug.Log("Chowed on the crumb");
            
            NewGum = Instantiate(PrefabGum, NewCubePosition, Quaternion.identity) as GameObject;
            NewGum.transform.parent = NewCube.transform;
            NewGum.transform.localPosition = handAttach.localPosition;
            NewGum.gameObject.name = "Gum";
            NewCube.GetComponent<MeshRenderer>().enabled = false;
            //NewCube.GetComponent<MeshCollider>().enabled = false;
            StartCoroutine(DestroySelf());
            

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        audioS.Play();
        Debug.Log("triggered eatcollider");
    }
}