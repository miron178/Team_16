using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrench : MonoBehaviour
{
    public puddleCheck puddle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wrench")
        {
            puddle.nutAttached();
        }
    }
}
