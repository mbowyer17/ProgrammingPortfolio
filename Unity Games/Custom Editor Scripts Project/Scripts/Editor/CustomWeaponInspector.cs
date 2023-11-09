using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WeaponScript))]
public class CustomWeaponInspector : Editor
{
    int gridIndex;
    public override void OnInspectorGUI()
    {
        WeaponScript ws = (WeaponScript)target;

        
    }
}
