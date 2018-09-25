using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkToGum : MonoBehaviour {

   
    public Transform gumPrefab;
    AudioSource headAudio;
    Transform crumb;

    Transform newGum;

    void Start()
    {
        headAudio = this.GetComponent<AudioSource>();
    }

	public void OnCollisionEnter(Collision other)
    {
        
        if (other.collider.name == "mouth-collider")
        {
            Debug.Log("collided with mouth");
            headAudio.Play();
            crumb = this.gameObject.transform.Find("Crumb");
            newGum = Instantiate(gumPrefab, crumb.transform.position, Quaternion.identity) as Transform;
            newGum.parent = gameObject.transform;
            newGum.localRotation = Quaternion.identity;
            newGum.gameObject.name = "Gum";
            this.gameObject.tag = "bread";
            Destroy(crumb.gameObject);
        }
        
    }

}
