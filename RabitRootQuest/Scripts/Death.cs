using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            FindObjectOfType<AudioManager>().PlayAudio("DeathWater");
            Invoke("GameOverPanel", 1f);
        }
    }

    void GameOverPanel()
    {
            SceneManager.LoadScene("GameOverTestScene");
    }
}
