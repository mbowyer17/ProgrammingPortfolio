using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Mortis_Weapon_Phase2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotate = Time.deltaTime * 20f;
        transform.Rotate(new Vector3(0, rotate, 0));
    }
}
