using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomJump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player2")
        {
            FindObjectOfType<AudioManager>().PlayAudio("Bounce");
            var jumpCol = col.gameObject.GetComponent<SecondPlayerMovement>();
            jumpCol.Jump(22);
            Debug.Log("Hello");
        }
    }
}
