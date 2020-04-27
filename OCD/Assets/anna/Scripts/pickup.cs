using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public Transform des;
    public Transform des2;
    public Transform des3;
    public Transform des4;
    bool inRange = false;

    private void Update()
    {
        if(inRange)
        {
            if(Input.GetKey(KeyCode.E))
            {
                PickUp();

            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                PickUp2();
            }
            if (Input.GetKey(KeyCode.Keypad4))
            {
                PickUp3();
            }
            if (Input.GetKey(KeyCode.O))
            {
                PickUp4();
            }
        }

    }

    private void PickUp()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = des.position;
        this.transform.parent = GameObject.Find("destination").transform;
        if (Input.GetKey(KeyCode.E))
        {
            Drop();

        }
    }
    private void PickUp2()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = des2.position;
        this.transform.parent = GameObject.Find("destination2").transform;
        if (Input.GetKey(KeyCode.RightShift))
        {
            Drop();
        }

    }
    private void PickUp3()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = des3.position;
        this.transform.parent = GameObject.Find("destination3").transform;
        if (Input.GetKey(KeyCode.Keypad4))
        {
            Drop();
        }

    }
    private void PickUp4()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = des4.position;
        this.transform.parent = GameObject.Find("destination4").transform;
        if (Input.GetKey(KeyCode.O))
        {
            Drop();
        }

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
    public void isNotInRange()
    {
        inRange = false;
    }
}
