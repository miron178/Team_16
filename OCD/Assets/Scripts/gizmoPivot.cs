using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmoPivot : MonoBehaviour
{
    public float gizmoSize = 0.75f;
    public Color gizmoColour = Color.red;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColour;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}
