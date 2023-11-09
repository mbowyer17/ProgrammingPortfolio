using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TerrainHandles))]
public class OnMouseHandle : Editor
{
    public Vector3 currentMouseHandle = Vector3.zero;

    void OnSceneGUI()
    {
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Debug.Log(hit.point);
            currentMouseHandle = hit.point;
            Handles.color = Color.red;
            Handles.DrawWireCube(currentMouseHandle, Vector3.one * 2);
            UpdatePaint();
        }
    }
    void UpdatePaint()
    {
        SceneView.RepaintAll();
    }
 
}
