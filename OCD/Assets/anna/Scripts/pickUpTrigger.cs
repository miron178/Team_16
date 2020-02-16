using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpTrigger : MonoBehaviour
{
    public pickup _pickup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Player2" || 
        other.gameObject.tag == "Player3" || other.gameObject.tag == "Player4" )
        {
            _pickup.isInRange(); 
        }
       
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Player2" ||
        other.gameObject.tag == "Player3" || other.gameObject.tag == "Player4")
        {
            _pickup.isNotInRange();
        }
    }
}
