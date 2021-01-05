using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosSphere : MonoBehaviour
{
    [SerializeField] Color color = Color.red;
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }
}
