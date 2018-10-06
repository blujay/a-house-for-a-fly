using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEasy : MonoBehaviour {

   
    public GameObject frontLayer;
    public GameObject flyHouse;
    public GameObject mainFly;
    public bool houseComplete = false;



    [HideInInspector] public int frontLayerGums;
    [HideInInspector] public int brickCount;

    // Use this for initialization
    void Start () {

        brickCount = 1;

        flyHouse.SetActive(false);

        frontLayerGums = frontLayer.transform.childCount;
        Debug.Log("number of gums in frontlayer is: " + frontLayerGums);

    }

    

    // Update is called once per frame
    void Update () {

        if (!houseComplete) { MakeFrontLayer(); }
        if(houseComplete)
        {
            flyHouse.SetActive(true);
            mainFly.SetActive(false);
        }
    }

    void MakeFrontLayer()
    {
        frontLayer.SetActive(true);
        Debug.Log("number of gums in frontlayer so far = " + brickCount);
        if (brickCount == frontLayerGums)
        {
            houseComplete = true;
            Debug.Log("House complete!");
            brickCount = 0;

        }
    }

    

    public void CountBreadStick()
    {
        brickCount++;
    }


}
