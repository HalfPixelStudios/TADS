using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad()]
public class TrafficControllerEditor
{
    [DrawGizmo(GizmoType.Selected)]
    public static void OnDrawSceneGizmo(TrafficFSM wayPoint, GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.yellow*0.5f;
        }

        float radius = 0;
        Gizmos.DrawSphere(wayPoint.transform.position,0.8f);
        Gizmos.color=Color.blue;
    }
}
