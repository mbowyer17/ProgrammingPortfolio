using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject textObject;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
    }


}
