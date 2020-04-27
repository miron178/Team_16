using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toyCollected : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "toy")
        {
            other.gameObject.SetActive(false);
        }
        
    }
}
