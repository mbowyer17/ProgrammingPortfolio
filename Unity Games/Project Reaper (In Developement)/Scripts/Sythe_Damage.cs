using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sythe_Damage : MonoBehaviour
{
    [SerializeField] 
    private float baseDamage = 10f;

    [SerializeField] private Player_Stats playerStats;

    [SerializeField] private Npc_Controller npcHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        //playerStats = GameObject.FindWithTag("Player").GetComponent<Player_Stats>();
        //baseDamage = baseDamage + playerStats.attackPower;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter detected: " + other.gameObject.name);

        if (other.CompareTag("Npc") && gameObject.activeSelf)
        {
            Debug.Log("Object hit an NPC trigger. Applying damage.");

            Npc_Controller npcHealth = other.gameObject.GetComponent<Npc_Controller>();
            if (npcHealth != null)
            {
                float damageAmount = baseDamage * playerStats.attackPower;
                npcHealth.TakeDamage(damageAmount);
                Debug.Log("Damage: " + damageAmount);
            }
        }
    }

    public void UpdateDamage()
    {
        baseDamage = baseDamage + playerStats.attackPower;
    }
}
