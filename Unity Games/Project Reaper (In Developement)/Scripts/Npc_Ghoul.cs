using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Ghoul : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Npc_Stats stats;
    [SerializeField] private GameObject attackPrefab, attackPosition;
    [SerializeField] private float shotDelay = 3f;
    [SerializeField] private float timer;
    // Start is called before the first frame update
    void Start()
    {
        stats.health = 100;
        stats.speed = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
            if (distance < stats.ai_range)
            {
                // Make this ghoul ATTACK
                Attack();
            }
        }
    }
    public void Attack()
    {
        timer += Time.deltaTime;

        if (timer >= shotDelay)
        {

            Instantiate(attackPrefab, attackPosition.transform.position, Quaternion.identity);
            timer = 0;

        }

        //Instantiate(attackPrefab, gameObject.transform);
    }
}
