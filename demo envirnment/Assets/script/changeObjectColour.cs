using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeObjectColour : MonoBehaviour
{
    public GameObject[] toy;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }
        foreach (GameObject i in toy) {
            i.transform.GetComponent<Renderer>().material.color = Color.yellow;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }
        foreach (GameObject i in toy) {
            i.transform.GetComponent<Renderer>().material.color = Color.white;
        }
        
    }
}
