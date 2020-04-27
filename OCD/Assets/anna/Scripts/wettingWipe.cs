using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wettingWipe : MonoBehaviour
{
    public GameObject wettedWipe;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "stainRemover")
        {
            gameObject.SetActive(false);
            wettedWipe.SetActive(true);
        }
    }
}
