using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLight : MonoBehaviour
{
    [SerializeField]Animation clip;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            clip.Play();
            Debug.Log("Test");
            timer = 0f;
        }
    }
}
