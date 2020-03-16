using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeAsh : MonoBehaviour
{
    public ash ashDust;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ash")
        {
            ashDust.cleaned();
        }
    }
}
