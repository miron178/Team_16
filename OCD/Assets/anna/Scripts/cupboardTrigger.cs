//made by anna 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupboardTrigger : MonoBehaviour
{
    public openDoor trigger; //creates link to open door script
    public closeDoor trigger2; //creates link to close door script
    private void OnTriggerEnter(Collider other) //if entered the trigger
    {
        if (other.gameObject.tag != "Player") //if not player
        {
            return; //end
        }
        trigger.entered = true; //set bool to true
        trigger2.entered = true; //set bool to true
    }

    private void OnTriggerExit(Collider other) //if exited the trigger
    {
        if (other.gameObject.tag != "Player") //if not player
        {
            return; //end
        }

        trigger.endDoorOpen(); //activate function
        trigger2.endCloseDoor(); //activate function
    }
}
