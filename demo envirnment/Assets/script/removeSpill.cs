using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeSpill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mop")
        {
            gameObject.SetActive(false);
        }
    }
}
