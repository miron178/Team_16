using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stainRemoverScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "stainRemover")
        {
            gameObject.SetActive(false);
        }
       
    }
}
