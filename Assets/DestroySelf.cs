using UnityEngine;
using System.Collections;
using VRTK;

public class DestroySelf : MonoBehaviour
{
    

    private void OnEnable()
    {
        Destroy(this.gameObject);
    }

}