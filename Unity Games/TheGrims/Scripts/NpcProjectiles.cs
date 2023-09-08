using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcProjectiles : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] PlayerInventory health;
    [SerializeField] GameObject npc;
    [SerializeField] bool traceBullet, normalBullet;
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] CircleCollider2D playerCircle;

    [SerializeField] protected AudioManager audioManager;
    Transform player;
    Vector2 target;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioManager.AudioNpcShoot();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Physics2D.IgnoreLayerCollision(8, 9);

        if (normalBullet)
        {
            transform.position = Vector2.Lerp(transform.position, target, speed * Time.deltaTime);
          
        }
        if (traceBullet)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            
        }

        if (timer >= 2f) 
        {
            timer = 0f;
            Destroy(gameObject);
        }

        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //health = collision.gameObject.GetComponent<PlayerInventory>();
        
        if (collision.collider == collision.gameObject.GetComponent<BoxCollider2D>() && collision.gameObject.tag == "Player")
        {
            
            playerSprite = collision.gameObject.GetComponent<SpriteRenderer>();
            playerSprite.color = Color.red;
            health.DamageToPlayer(damage);
            Destroy(gameObject);


        }
        else if (collision.collider == collision.gameObject.GetComponent<CircleCollider2D>())
        {
            
            print("Hit Shield");
            
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouching(playerCircle))
        {
            print("CIRCLE FOUND");
        }
    }

    

}
