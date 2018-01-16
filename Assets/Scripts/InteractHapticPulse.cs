using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using VRTK;

/* Currently only works on oculus
 * The VRTK Haptic system only allows for AudioClips which can't be created completely from scratch at runtime 
 *  PLEASE NOTE: This class is simlpistic and is intented to be modified only in the Editor, all
 *  listeners are attached when first XR device is enabled
 */
public class InteractHapticPulse : MonoBehaviour
{
    [SerializeField]
    private HapticPulse onTouchPulse;
    [SerializeField]
    private HapticPulse onGrabPulse;
    [SerializeField]
    private HapticPulse onUsedPulse;

    private bool initDone;

    private void Update()
    {
        if (!initDone && XRSettings.enabled && XRSettings.loadedDeviceName.Contains("Oculus"))
        {
            Init();
        }

    }

    void Init() {
        var interactable = GetComponent<VRTK.VRTK_InteractableObject>();
        if ( onGrabPulse ) {
            interactable.InteractableObjectGrabbed += GenerateHandler(onGrabPulse);
        }
        if (onUsedPulse)
        {
            interactable.InteractableObjectGrabbed += GenerateHandler(onUsedPulse);
        }

        if (onTouchPulse)
        {
            interactable.InteractableObjectGrabbed += GenerateHandler(onTouchPulse);
        }
        initDone = true;
    }

    private InteractableObjectEventHandler GenerateHandler(HapticPulse pulse) {
        OVRHapticsClip hapticClip = new OVRHapticsClip(pulse.GetBytes(),pulse.Length);


        return (object sender, InteractableObjectEventArgs args) =>{
            var controller = args.interactingObject.GetComponentInParent<VRTK_TrackedController>();
            if (controller)
            {
                OVRHaptics.Channels[controller.index].Preempt(hapticClip);
            }
        };
    }
}
