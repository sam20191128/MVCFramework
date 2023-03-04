using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGizmo : MonoBehaviour
{
    public float radius = 1f;
    public int segments = 32;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        float angle = 360f / segments;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        Vector3 direction = Vector3.forward * radius;

        for (int i = 0; i < segments; i++)
        {
            Gizmos.DrawLine(transform.position + direction, transform.position + (rotation * direction));
            direction = rotation * direction;
        }
    }
}