using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{

    public GameObject PrefabCrumb;
    public GameObject spawnPoint;
    public AudioSource breadGrabAudioSource;
    public SoundCollection breadSounds;
    StickGum stickGum;
    GameObject NewCrumb; // NewCrumbPrefab

    void Start()
    {
        this.enabled = false;
    }



    void OnEnable()
    {
        Debug.Log("Script enabled");
        NewCrumb = Instantiate(PrefabCrumb, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        breadGrabAudioSource.Play();
        breadSounds.Play(breadGrabAudioSource);
        NewCrumb.gameObject.name = "NewCrumb";
        stickGum = NewCrumb.GetComponent<StickGum>();
        stickGum.enabled = false;

    }
    
}