using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RobotNpcController : MonoBehaviour
{
    // The target marker.
    [SerializeField] Transform player;
    [SerializeField] GameObject head;
    Vector3 newDirection;
    // Angular speed in radians per sec.
    [SerializeField] float speed = 10.0f;
    [SerializeField] NavMeshAgent agents;
    [SerializeField] Vector3 targetDirection;
    [SerializeField]float hitTimer = 0;
    [SerializeField] Animator animator;

    enum RobotStates { 
    idle,
    walking,
    attacking,

    
    }
    RobotStates animation = RobotStates.idle;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        
        switch (animation)
        {
            case RobotStates.idle:
                animator.SetBool("isIdle", true);
                animator.SetBool("isWalking", false);
                animator.SetBool("isHiting", false);
                break;
            case RobotStates.walking:
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalking", true);
                animator.SetBool("isHiting", false);
                break;
            case RobotStates.attacking:
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalking", false);
                animator.SetBool("isHiting", true);
                break;
            default:
                break;
        }
        LookAtPlayer();
        AttackPlayer();
  
    }

    void AttackPlayer()
    {
        
        Vector3 rayDirection = transform.TransformDirection(Quaternion.Euler(0, 0, 0) * Vector3.forward) * 3f;
        hitTimer -= Time.deltaTime;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, rayDirection, out hit, 3f) && hit.collider.tag == "Player")
        {
            Debug.DrawRay(transform.position, rayDirection, Color.red);
            
            agents.isStopped = true;
            if (hitTimer <= 0f)
            {
                animation = RobotStates.attacking;
                hit.collider.gameObject.GetComponent<PlayerInventory>().AddHealth(-10);
                hitTimer = 3f;
            }
            
        }
        
    }
    void LookAtPlayer()
    {
        animation = RobotStates.idle;
        targetDirection = player.position - head.transform.position;
        
        if (targetDirection.z <= 10f)
        {
            agents.isStopped = false;
            print("HelloWorld");
            float turnSpeed = speed * Time.deltaTime;

            newDirection = Vector3.RotateTowards(head.transform.forward, targetDirection, turnSpeed, 0.0f);


            Debug.DrawRay(head.transform.position, newDirection, Color.red);

            head.transform.rotation = Quaternion.LookRotation(newDirection);

            animation = RobotStates.walking;
            agents.destination = player.position;
           
        }
       
    }
}