using UnityEngine;
using System.Collections;
using VRTK;

public class lightOn : MonoBehaviour
{

    public Light roomLight;

    void Start()
    {
        roomLight.enabled = false;
        roomLight.color = Color.blue;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameController")
        {
            roomLight.enabled = true;
        }
    }
}