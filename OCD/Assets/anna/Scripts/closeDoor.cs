//made by Anna
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : MonoBehaviour
{
    public openDoor open; //takes in link to open door script
    public Animator doorClose; //creates a new animator
    public bool entered = false; //bool checking if the trigger was set off
    void Start()
    {

        doorClose = GetComponentInChildren<Animator>(); //sets the needed animator 
    }
    private void Update()
    {
        if (entered == true) //if triggered
        {
            if (Input.GetKeyDown(KeyCode.R)) //and r key was pressed
            {
                DoorClose(); //run function

            }
            
        }
    }
    private void DoorClose()
    {
        doorClose.SetBool("close", true); //send to the animator that the paramter is now true
       
    }
    public void endCloseDoor()
    {
        doorClose.SetBool("close", false); //send to the animator that the paramter is now false
    }
}
