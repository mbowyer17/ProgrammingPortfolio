using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStats : MonoBehaviour
{
    [SerializeField] int startingHealth;
    [SerializeField] int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    private void Update()
    {
        if (GetHealth() <= 0)
        {
            EnemyDeath();
        }
    }
    void EnemyDeath()
    {
        //Maybe add ragdoll effect
        Destroy(gameObject);
    }
    void EnemyHit()
    {
        // Make the enemy turn red when hit

    }
    public int GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(int healthamount)
    {
        currentHealth += healthamount;
        
    }

}
