//written by Anna
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireCheck : MonoBehaviour
{
    public GameObject fire;//takes in game object
    public float countdown = 5.0f;//float that is set to how long object takes before being set active again
    void Update()
    {
        countdown -= Time.deltaTime; //start ticking down countdown
        if (countdown <= 0)//once its hit zero
        {
            fire.SetActive(true); //set the object to active again
        }
    }
    public void extinguished()//function which sets the object to inactive and reset the countdown
    {
        fire.SetActive(false);
        countdown = 5.0f;
    }
    
}
