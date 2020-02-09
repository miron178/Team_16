using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public Animator doorAmi; //creates a new animator
    public closeDoor setCloseDoor;
    public bool entered = false;
    void Start()
    {

        doorAmi = GetComponentInChildren<Animator>(); //sets the needed animator 
    }
    private void Update()
    {
        if (entered == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorOpen();  
            }
           
        }
    }
    private void DoorOpen()
    {
        doorAmi.SetBool("open", true);
    }
    public void endDoorOpen()
    {
        doorAmi.SetBool("open", false);
    }


}
