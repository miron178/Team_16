using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : MonoBehaviour
{
    public openDoor open;
    public Animator doorClose; //creates a new animator
    public bool entered = false;
    void Start()
    {

        doorClose = GetComponentInChildren<Animator>(); //sets the needed animator 
    }
    private void Update()
    {
        if (entered == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                DoorClose();

            }
            
        }
    }
    private void DoorClose()
    {
        doorClose.SetBool("close", true);
       
    }
    public void endCloseDoor()
    {
        doorClose.SetBool("close", false);
    }
}
