using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem hitParticle;
    public int healthAmount;

    public void DealDamage(int damage)
    {
        healthAmount -= damage;
        Instantiate(hitParticle, gameObject.transform.position, Quaternion.identity);
        
    }
    
    
    
}
