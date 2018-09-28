using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour {

   
    public GameObject backLayer;
    public GameObject middleLayer;
    public GameObject frontLayer;
    public GameObject fly;
    bool backLayerComplete;
    bool middleLayerComplete;
    bool houseComplete;



    [HideInInspector] public int backLayerGums;
    [HideInInspector] public int middleLayerGums;
    [HideInInspector] public int frontLayerGums;
    [HideInInspector] public int brickCount;

    // Use this for initialization
    void Start () {

        brickCount = 0;

        middleLayer.SetActive(false);
        frontLayer.SetActive(false);
        fly.SetActive(false);

        backLayerGums = backLayer.transform.childCount;
        Debug.Log("number of gums in backlayer is: " + backLayerGums);

        middleLayerGums = middleLayer.transform.childCount;
        Debug.Log("number of gums in middlelayer is: " + middleLayerGums);

        frontLayerGums = frontLayer.transform.childCount;
        Debug.Log("number of gums in frontlayer is: " + frontLayerGums);

    }

    

    // Update is called once per frame
    void Update () {

        if (!backLayerComplete) { MakeBackLayer(); }
        if(backLayerComplete && !middleLayerComplete) { MakeMiddleLayer(); }
        if(middleLayerComplete) { MakeFrontLayer(); }
        if(houseComplete) { fly.SetActive(true); }
    }

    void MakeBackLayer()
    {
        backLayer.SetActive(true);
        Debug.Log("number of gums in backlayer so far = " + brickCount);
        if (brickCount == backLayerGums)
        {
            backLayerComplete = true;
            Debug.Log("back layer complete: " + brickCount);
            brickCount = 0;

        }
    }

    void MakeMiddleLayer()
    {
        middleLayer.SetActive(true);
        Debug.Log("number of gums so far in middle layer is: " + brickCount);
        if (brickCount == middleLayerGums)
        {
            middleLayerComplete = true;
            Debug.Log("middle layer complete: " + brickCount);
            brickCount = 0;
        }
    }

    void MakeFrontLayer()
    {
        frontLayer.SetActive(true);
        Debug.Log("number of gums in frontlayer is: " + brickCount);
        if (brickCount == frontLayerGums)
        {
            houseComplete = true;
            Debug.Log("house complete: " + brickCount);
            brickCount = 0;
        }
    }

    public void CountBreadStick()
    {
        brickCount++;
    }


}
