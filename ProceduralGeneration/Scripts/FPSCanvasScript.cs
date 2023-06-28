using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCanvasScript : MonoBehaviour
{
   
    public float deltaTime;
    public TMP_Text text;
    public int fpsArraySize = 300;
    private int index;
    private float[] fpsArray;

    private void Start()
    {
        fpsArray = new float[fpsArraySize];
    }

    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        // Print the fpsArray
        string fpsArrayString = "FPS Array: ";
        for (int i = 0; i < fpsArraySize; i++)
        {
            fpsArrayString += fpsArray[i].ToString() + ", ";
        }
        Debug.Log(fpsArrayString);
    }

    private void FixedUpdate()
    {
        float fps = 1.0f / deltaTime;
        //Debug.Log("FPS: " + fps);
        text.text = "FPS: " + fps;

        if (index < fpsArraySize)
        {
            fpsArray[index] = fps;
            index++;
        }
        else
        {
            index = 0;
            fpsArray[index] = fps;
        }
    }
}
