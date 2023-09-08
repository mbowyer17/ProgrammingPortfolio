using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float radius = 1f;

    public float speed = 0.5f;

    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = Random.Range(0.5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        float rotate = Time.deltaTime * rotateSpeed;
        transform.Rotate(new Vector3(0, rotate, rotate));
    }
}
