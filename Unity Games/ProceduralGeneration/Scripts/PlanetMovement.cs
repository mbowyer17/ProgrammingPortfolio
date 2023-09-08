using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    public float radius = 1f;

    public float speed = 0.5f;

    public float rotateSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        radius = UnityEngine.Random.Range(2000f, 100000f);
        speed = Random.Range(0.05f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Time.time * speed;
        float rotate = Time.deltaTime * rotateSpeed;
        
        float x = Mathf.Sin(angle) * radius;
        float z = Mathf.Cos(angle) * radius;
        transform.position = new Vector3(x, transform.position.y, z);
        transform.Rotate(new Vector3(0, rotate, rotate));
    }
}
