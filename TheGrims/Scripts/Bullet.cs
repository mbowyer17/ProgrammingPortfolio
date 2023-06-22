using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damageAmount;
    [SerializeField] NpcHealth npcHealth;
    [SerializeField] AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            audioManager.AudioNpcHit();
            npcHealth = collision.gameObject.GetComponent<NpcHealth>();
            npcHealth.DealDamage(damageAmount);
            Destroy(gameObject);
          

        }
        else if (collision.gameObject.tag == "Enviroment")
        {
            Destroy(gameObject);
        }
    }
}
