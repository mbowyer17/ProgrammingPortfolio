using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Ghoul_Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 100f; // Adjust this value for the desired speed
    private Transform target; // The target NPC's transform

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; 

        // Apply initial velocity to point towards the target
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit");
            other.GetComponent<Player_Controller>().TakeDamage(5f);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

}
