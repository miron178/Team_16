//made by Anna
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public Animator doorAmi; //creates a new animator
    public closeDoor setCloseDoor;//takes in link to close door script
    public bool entered = false;//bool checking if the trigger was set off
    void Start()
    {

        doorAmi = GetComponentInChildren<Animator>(); //sets the needed animator 
    }
    private void Update()
    {
        if (entered == true)//if triggered
        {
            if (Input.GetKeyDown(KeyCode.E)) //and e key was pressed
            {
                DoorOpen();   //run function
            }
           
        }
    }
    private void DoorOpen()
    {
        doorAmi.SetBool("open", true); //send to the animator that the paramter is now true
    }
    public void endDoorOpen()
    {
        doorAmi.SetBool("open", false);//send to the animator that the paramter is now false
    }


}
