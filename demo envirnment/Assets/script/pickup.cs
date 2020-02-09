using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public Transform des;
    bool inRange = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (inRange)
            {
                PickUp();
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            Drop();
        }
        
    }

    private void PickUp()
    {
         GetComponent<Rigidbody>().useGravity = false;
         this.transform.position = des.position;
         this.transform.parent = GameObject.Find("destination").transform;
         inRange = false;
    }
    private void Drop()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
    public void isInRange()
    {
        inRange = true;
    }
 
    

}
       