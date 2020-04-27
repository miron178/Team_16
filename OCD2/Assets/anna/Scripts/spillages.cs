using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spillages : MonoBehaviour
{
    public Transform spillagePos;
    public GameObject spillage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "stainRemover")
        {
            Instantiate(spillage, spillagePos.position, spillagePos.rotation);
        }
    }
}
