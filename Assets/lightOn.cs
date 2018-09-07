using UnityEngine;
using System.Collections;
using VRTK;

public class lightOn : MonoBehaviour
{

    public Light roomLight;

    private void OnEnable()
    {
       roomLight.enabled = true;
    }

    private void OnDisable()
    {
        roomLight.enabled = false;
    }
}