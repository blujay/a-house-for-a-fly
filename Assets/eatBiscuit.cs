using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatBiscuit : MonoBehaviour {

    public Transform PrefabCookieHalf;
    public Transform PrefabCookieCrumb;
    public AudioSource audioS;
    public AudioClip firstBite;
    public AudioClip secondBite;
    public AudioClip lastBite;

    int collisionCount;
    
    Transform halfCookie;
    Transform wholeCookie;
    Transform crumb;

    IEnumerator DestroySelf()
    {
        print(Time.time);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }


    void Start()
    {
        audioS.playOnAwake = false;
        wholeCookie = this.gameObject.transform.Find("cookie-whole");
    }


    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Collided with " + other.collider.gameObject.name);
        if (other.collider.name == "mouth-collider")
        {

            if (collisionCount == 0)
            {
                audioS.PlayOneShot(firstBite);
                halfCookie = Instantiate(PrefabCookieHalf, transform.position, Quaternion.identity) as Transform;
                //Debug.Log("half cookie instantiated");
                halfCookie.parent = gameObject.transform;
                halfCookie.localRotation = Quaternion.identity;
                Destroy(wholeCookie.gameObject);


            }

            else if (collisionCount == 1)
            {

                audioS.PlayOneShot(secondBite);
                crumb = Instantiate(PrefabCookieCrumb, transform.position, Quaternion.identity) as Transform;
                //Debug.Log("half cookie instantiated");
                crumb.parent = gameObject.transform;
                crumb.localRotation = Quaternion.identity;
                Destroy(halfCookie.gameObject);

            }

            else if (collisionCount == 2)
            {
                audioS.PlayOneShot(lastBite);
                Destroy(crumb.gameObject);
                StartCoroutine(DestroySelf());
            }
         
            collisionCount++;
            //Debug.Log("collision " + collisionCount);
        }

    }

}

