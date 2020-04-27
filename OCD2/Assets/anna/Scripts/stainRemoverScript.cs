using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stainRemoverScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wipe")
        {
            gameObject.SetActive(false);
        }
       
    }
}
