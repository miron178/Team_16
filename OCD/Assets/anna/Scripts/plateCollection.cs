using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateCollection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "plate")
        {
            other.gameObject.SetActive(false);
        }

    }
}
