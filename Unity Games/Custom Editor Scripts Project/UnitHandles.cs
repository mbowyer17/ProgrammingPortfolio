using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHandles : MonoBehaviour
{
    Vector3 position;
    Unit2Controller unit2;
    Unit1Controller unit1;
    public int currentTarget, currentTarget2;
    private void Start()
    {
        position = this.gameObject.transform.position;
        unit2 = GetComponent<Unit2Controller>();
        unit1 = GetComponent<Unit1Controller>();
    }
    private void Update()
    {
        currentTarget = unit2.GetCurrentTarget();
    }
    void OnSceneGUI()
    {
        
    }
}
