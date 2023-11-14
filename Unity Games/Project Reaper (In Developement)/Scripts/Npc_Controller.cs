using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Npc_Controller : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Npc_Stats npcStats;
    [SerializeField] private TMP_Text damageText;
    [SerializeField] public float health;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        //damageText.enabled = false;
        health = npcStats.health;
        print(gameObject.name + " " + npcStats.health);
    }

    private void Update()
    {
        //damageText.gameObject.transform.position += Vector3.up * 0.001f;
        if (health <= 0)
        {
            Death();
        }
    }


    public void TakeDamage(float damage)
    {
        //damageText.gameObject.transform.localPosition = new Vector3(transform.position.x, .748f);
        //damageText.enabled = true;
        health -= damage;
        //damageText.text = damage.ToString();
        StartCoroutine(textDisable());
    }

    private IEnumerator textDisable()
    {
     
        yield return new WaitForSeconds(1.5f);
        //damageText.enabled = false;
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
