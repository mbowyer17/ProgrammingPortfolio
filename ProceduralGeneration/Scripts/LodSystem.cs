using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LodSystem : MonoBehaviour
{
    public GameObject[] LODs1;
    public GameObject[] LODs2;
    public GameObject[] LODs3;

    public float maxDistance1 = 50.0f;
    public float maxDistance2 = 100.0f;
    public float maxDistance3 = 150.0f;

    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        for (int i = 0; i < LODs1.Length; i++)
        {
            float distance = Vector3.Distance(LODs1[i].transform.position, cameraTransform.position);

            if (distance < maxDistance1)
            {
                LODs1[i].SetActive(true);
                LODs2[i].SetActive(false);
                LODs3[i].SetActive(false);
            }
            else if (distance >= maxDistance1 && distance < maxDistance2)
            {
                LODs1[i].SetActive(false);
                LODs2[i].SetActive(true);
                LODs3[i].SetActive(false);
            }
            else if (distance >= maxDistance2 && distance < maxDistance3)
            {
                LODs1[i].SetActive(false);
                LODs2[i].SetActive(false);
                LODs3[i].SetActive(true);
            }
            else
            {
                LODs1[i].SetActive(false);
                LODs2[i].SetActive(false);
                LODs3[i].SetActive(false);
            }
        }
    }
}
