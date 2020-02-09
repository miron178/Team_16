using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireExtinguisher : MonoBehaviour
{
    public fireCheck fire;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "extinguisher")
        {
            fire.extinguished();
        }
    }
}
