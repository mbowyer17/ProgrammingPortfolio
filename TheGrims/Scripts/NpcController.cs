using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class NpcController : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] bool wandering;
        [SerializeField] GameObject player;

        // Update is called once per frame
        void Update()
        {


            try
            {
                player = GameObject.FindGameObjectWithTag("Player");
                if (wandering)
                {
                    
                    WalkToPlayer();
                }
            }
            catch (System.NullReferenceException e)
            {

                print("Could not find Player " + e);
                throw;
            }
        }

        void WalkToPlayer()
        {

            float distance = Vector2.Distance(transform.position, player.transform.position);
      
            if (distance <= 2)
            {
                transform.position = transform.position;

            }
            else
            {
                transform.position = Vector2.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);

            }
        }
    }


