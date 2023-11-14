using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc_Movement : MonoBehaviour
{
    [SerializeField] private Transform player;        // Reference to the player's Transform
    [SerializeField] private NavMeshAgent navAgent;  // Reference to the NavMeshAgent component
    [SerializeField] private Npc_Stats stats;
    private void Start()
    {
        // Get the NavMeshAgent component attached to the same GameObject
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = stats.speed;

        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned!");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Set the destination of the NavMeshAgent to the player's position
            navAgent.SetDestination(player.position);
        }
    }
}
