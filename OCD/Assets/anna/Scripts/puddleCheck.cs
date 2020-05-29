//made by Anna
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleCheck : MonoBehaviour
{
    public GameObject puddle;//takes in game object
    public float countdown = 40.0f; //float that is set to how long object takes before being set active again
    void Update()
    {
        if (gameObject.activeSelf==true) //if attached game object is active
        {
            puddle.SetActive(false); //set to inactive
        }
        countdown -= Time.deltaTime; //decrease countdown
        if(countdown <= 0) //once at 0
        {
            gameObject.SetActive(false); //set attached object to inactive
            puddle.SetActive(true); //set puddle to active
        }
    }
    public void nutAttached()
    {
        gameObject.SetActive(true); //set attached object to active
        countdown = 40.0f; //reset countdown
    }
}
