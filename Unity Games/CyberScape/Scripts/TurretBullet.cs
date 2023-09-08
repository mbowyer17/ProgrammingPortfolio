using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
     
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            player.GetComponent<PlayerInventory>().AddHealth(-10);
            Destroy(this.gameObject);
            
        }
        
            
        
    }
    
}
