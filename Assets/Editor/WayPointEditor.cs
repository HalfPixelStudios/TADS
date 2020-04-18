using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad()]
public class WayPointEditor
{
    [DrawGizmo(GizmoType.NonSelected|GizmoType.Pickable|GizmoType.Selected)]
    public static void OnDrawSceneGizmo(WayPoint wayPoint, GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.yellow*0.5f;
        }
        Gizmos.DrawSphere(wayPoint.transform.position,5f);
        Gizmos.color=Color.blue;

        foreach (WayPoint node in wayPoint.connections )
        {
            Gizmos.DrawLine(wayPoint.transform.position,node.transform.position);
        }
    }
}
