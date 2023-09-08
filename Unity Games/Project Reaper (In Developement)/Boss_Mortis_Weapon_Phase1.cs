using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boss_Mortis_Weapon_Phase1 : MonoBehaviour
{
    [SerializeField] private float initialUpwardSpeed = 30f; // Initial upward speed
    [SerializeField] private float minDistance = 5f; // Minimum distance from the player
    [SerializeField] private float maxDistance = 15f; // Maximum distance from the player
    [SerializeField] private Transform playerTransform;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * initialUpwardSpeed;

        playerTransform = GameObject.FindWithTag("Player").transform;

        // Generate a random direction biased towards the player's direction
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        Vector3 randomDirection = (directionToPlayer + Random.insideUnitSphere).normalized;

        // Calculate the random distance between minDistance and maxDistance
        float randomDistance = Random.Range(minDistance, maxDistance);

        rb.velocity = randomDirection * initialUpwardSpeed + directionToPlayer * randomDistance;
    }

    // Update is called once per frame
    void Update()
    {

        Destroy(this.gameObject, 5f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("HitPlayer");
            Destroy(this.gameObject);
        }
    }
}