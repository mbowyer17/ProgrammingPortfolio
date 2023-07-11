using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

[CustomEditor(typeof(UnitHandles))]
public class CustomGizmoEditor : Editor
{
    void OnSceneGUI()
    {
       UnitHandles uh = (UnitHandles)target;
        Handles.color = Color.red;
        EditorGUI.EndChangeCheck();
        var unitStats = uh.GetComponent<NavMeshAgent>();
        //var unit2Target = mc.GetComponent<Unit2Controller>();

        Vector3 position = uh.transform.position + Vector3.up * 0.3f;

        Handles.Label(position, uh.gameObject.name +
            "\nSpeed: " + unitStats.speed.ToString() +
            "\nAcceleration: " + unitStats.acceleration.ToString() +
            "\nAngularSpeed: " + unitStats.angularSpeed.ToString() +
            "\nTarget: " + uh.currentTarget.ToString(),
            GUI.skin.box);


      

        //Gizmos.DrawRay(mc.transform.position, unitStats.path.corners[1]); 
        //Handles.Label(position, "Position: " + mc.transform.position.ToString());
    }
}
