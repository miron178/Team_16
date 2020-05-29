//written by anna
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmoPivot : MonoBehaviour
{
    public float gizmoSize = 0.75f; //floar for the size of gizmo
    public Color gizmoColour = Color.red; //colour of gizmo

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColour; //setting the colour
        Gizmos.DrawWireSphere(transform.position, gizmoSize); //drawing at postion and size
    }
}
