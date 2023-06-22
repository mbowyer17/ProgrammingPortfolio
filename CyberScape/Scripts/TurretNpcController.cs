using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretNpcController : MonoBehaviour
{

    [SerializeField]Transform player;
    [SerializeField] GameObject head, bullet;
    Vector3 newDirection;

    [SerializeField] float speed;
    [SerializeField] float distance;
    [SerializeField] float shotDelay, timer;
    [SerializeField] AudioSource bulletAudio;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            LookAtPlayer();
        }
        

        
    }

    void LookAtPlayer()
    {

        Vector3 targetDirection = player.position - head.transform.position;

        if (targetDirection.z <= distance)
        {

            print("HelloWorld");
            float turnSpeed = speed * Time.deltaTime;

            newDirection = Vector3.RotateTowards(head.transform.forward, targetDirection, turnSpeed, 0.0f);

            Debug.DrawRay(head.transform.position, newDirection, Color.red);

            head.transform.rotation = Quaternion.LookRotation(newDirection);

            ShootAtPlayer();
        }
       
    }

    void ShootAtPlayer()
    {
        timer += Time.deltaTime;
        shotDelay = Random.Range(2f, shotDelay);

        if (timer >= shotDelay)
        {
            bulletAudio.Play();
            Instantiate(bullet, head.transform.position, Quaternion.identity);
            timer = 0;

        }
    }
}
