using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkToGum : MonoBehaviour {

   
    public Transform gumPrefab;
    AudioSource headAudio;
    Transform crumb;
    bool gumMade = false;

    Transform newGum;

    void Start()
    {
        headAudio = GetComponent<AudioSource>();
    }

	public void OnCollisionEnter(Collision other)
    {
        
        if (other.collider.name == "mouth-collider" && !gumMade)
        {
            Debug.Log("collided with mouth");
            headAudio.Play();
            crumb = gameObject.transform.Find("Crumb");
            newGum = Instantiate(gumPrefab, crumb.position, Quaternion.identity) as Transform;
            newGum.parent = gameObject.transform;
            newGum.localRotation = Quaternion.identity;
            newGum.gameObject.name = "Gum";
            gumMade = true;
            gameObject.tag = "bread";
            Destroy(crumb.gameObject);
            
        }
    }
}
