using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerPickUP : MonoBehaviour
{
    public pickup _pickup; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }
        _pickup.isInRange();
    }
    
}
