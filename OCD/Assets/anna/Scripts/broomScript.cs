using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broomScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "broom")
        {
            gameObject.SetActive(false);
        }

    }
}
