//written by Anna
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ash : MonoBehaviour
{
    public GameObject ashDust; //takes in game object
    public float countdown = 5.0f; //float that is set to how long object takes before being set active again
    void Update()
    {
        countdown -= Time.deltaTime; //start ticking down countdown
        if (countdown <= 0) //once its hit zero
        {
            ashDust.SetActive(true); //set the object to active again
        }
    }
    public void cleaned() //function which sets the object to inactive and reset the countdown
    {
        ashDust.SetActive(false);
        countdown = 5.0f;
    }
    
}
