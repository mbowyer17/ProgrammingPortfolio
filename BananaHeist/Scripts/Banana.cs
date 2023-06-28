using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public int damage;

    private Rigidbody rb;

    private bool targetHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Sticks to the first target
        if (targetHit)
            return;
        else
            targetHit = true;

        //Check for enemy
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }

        //Banana sticks to surface
        rb.isKinematic = true;

        //Banana moves with target
        transform.SetParent(collision.transform);
    }
}