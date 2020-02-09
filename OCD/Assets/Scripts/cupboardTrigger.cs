using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupboardTrigger : MonoBehaviour
{
    public openDoor trigger;
    public closeDoor trigger2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }
        trigger.entered = true;
        trigger2.entered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        trigger.endDoorOpen();
        trigger2.endCloseDoor();
    }
}
