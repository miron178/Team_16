using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeStain : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "stainRemover")
        {
            this.transform.GetComponent<Renderer>().material.color = Color.white;
            
        }

        if (other.gameObject.tag == "wipe" && GetComponent<Renderer>().material.color == Color.white)
        {
            gameObject.SetActive(false);
        }
    }
}
