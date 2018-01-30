using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class IlluminateOnGrab : MonoBehaviour {

    private VRTK_InteractableObject interactable;
    private Light bulbLight;
    private TrailRenderer trail;
    public bool trailsOn = false;


    void Start()
    {

        interactable = GetComponent<VRTK_InteractableObject>();
        interactable.InteractableObjectGrabbed += OnObjectGrabbed;
        interactable.InteractableObjectUngrabbed += OnObjectDropped;
        bulbLight = interactable.GetComponentInChildren<Light>();
        trail = interactable.GetComponentInChildren<TrailRenderer>();
    }


    void OnObjectGrabbed(object obj, InteractableObjectEventArgs args)
    {
        bulbLight.enabled = true;
        if (trailsOn) { trail.enabled = true; }
        
    }

    void OnObjectDropped(object obj, InteractableObjectEventArgs args)
    {
        bulbLight.enabled = false;
        if (!trailsOn) { trail.enabled = false; }

    }

}
