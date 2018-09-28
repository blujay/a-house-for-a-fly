using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{

    public GameObject PrefabCrumb;
    public GameObject spawnPoint;
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
        NewCrumb.gameObject.name = "NewCrumb";
        stickGum = NewCrumb.GetComponent<StickGum>();
        stickGum.enabled = false;

    }
    
}