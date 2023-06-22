using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] Rigidbody2D bullet;
    [SerializeField] GameObject player;
    [SerializeField] GameObject box;
    [SerializeField] bool abilityOne, abilityTwo, abilityThree;
    [SerializeField] ParticleSystem healed;

    PlayerInventory inventory;


    [SerializeField]CircleCollider2D playerShield;

    [SerializeField] float timer;
    [SerializeField] float cooldown;
    [SerializeField] float shieldTimer;
    [SerializeField] GameObject shieldSprite;
    bool shieldActivated = false;
    [SerializeField] bool spread;


    // Start is called before the first frame update
    void Start()
    {
       inventory = player.GetComponent<PlayerInventory>();

        playerShield.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && spread && inventory.GetAmmo() > 0)
        {
            SpreadShot();
            inventory.AddAmmo(-3);
        }
        else if (Input.GetMouseButtonDown(0) && !spread && inventory.GetAmmo() > 0)
        {
            Shoot();
            inventory.AddAmmo(-1);
        }
        if (Input.GetMouseButtonDown(1) && abilityOne && timer < 0)
        {
            Ability1();
            timer = cooldown;
        }
        if (Input.GetMouseButtonDown(1) && abilityTwo && timer < 0)
        {
            Ability2();
            Instantiate(healed, gameObject.transform);
            timer = cooldown;
        }
        if (Input.GetMouseButtonDown(1) && abilityThree && timer < 0)
        {
            Ability3();
            timer = cooldown;
            shieldActivated = true;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (shieldActivated)
        {
            shieldTimer += Time.deltaTime;
            shieldSprite.SetActive(true);
            if (shieldTimer >= 10f)
            {
                shieldSprite.SetActive(false);
                playerShield.enabled = false;
                player.GetComponent<BoxCollider2D>().enabled = true;
                shieldActivated = false;
                shieldTimer = 0f;
            }
        }
       
    }

    void Ability1()
    {
        cooldown = 30f;  
        GameObject ammoBox = Instantiate(box, transform.position + new Vector3(0, -1.5f), Quaternion.identity);
        
        
        
    }
    void Ability2()
    {
        cooldown = 20f;
        inventory.AddHealth(2);
        

    }
    void Ability3()
    {
        cooldown = 60f;
        playerShield.enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = false;
        
    }
    
 

    void Shoot()
    {

         
        Vector3 hitDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Not need to be honest, but will calculate and stores the rotation 
        float hitAngle = Mathf.Atan2(hitDirection.y, hitDirection.x) * Mathf.Rad2Deg; // Using tan formula to get the angle


        Vector3 difference = hitDirection - transform.position; // Checks the difference between the mouseposition and the current transform of the player
     
        float distance = difference.magnitude; 
        
        Vector2 direction = difference / distance; // Example  (0.0, 5.1, -9.5) / 10.82543 = (0.0, 0.5)


         Rigidbody2D shot;
         shot = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, hitAngle));


         shot.velocity = direction.normalized * bulletSpeed;
            
         Physics2D.IgnoreCollision(shot.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>()); //Ignores the player collision 
         Physics2D.IgnoreCollision(shot.GetComponent<BoxCollider2D>(), player.GetComponent<CircleCollider2D>()); 
       

    }


    void SpreadShot()
    {
        Vector3 hitDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Not need to be honest, but will calculate and stores the rotation 
        float hitAngle = Mathf.Atan2(hitDirection.y, hitDirection.x) * Mathf.Rad2Deg; // Using tan formula to get the angle
       

        Vector3 difference = hitDirection - transform.position; // Checks the difference between the mouseposition and the current transform of the player

        float distance = difference.magnitude;

        Vector2 direction = difference / distance; // Example  (0.0, 5.1, -9.5) / 10.82543 = (0.0, 0.5)

        
        Rigidbody2D shot, shot2, shot3;
        shot = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, hitAngle));
        shot2 = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, hitAngle));
        shot3 = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, hitAngle));

        shot.velocity = direction.normalized * bulletSpeed;
        shot2.velocity = direction.normalized * bulletSpeed + new Vector2(1f, 5f);
        shot3.velocity = direction.normalized * bulletSpeed + new Vector2(1f, -5f);

        Debug.DrawRay(transform.position, shot.velocity, Color.blue, 5f);
        Physics2D.IgnoreCollision(shot.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>()); //Ignores the player collision 
        Physics2D.IgnoreCollision(shot.GetComponent<BoxCollider2D>(), shot2.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(shot.GetComponent<BoxCollider2D>(), shot3.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(shot2.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(shot3.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(shot.GetComponent<BoxCollider2D>(), player.GetComponent<CircleCollider2D>());
        
    }
    //Encap
    public void SetAbility(string ability)
    {
        switch (ability)
        {
            case "abilityOne": 
                 abilityOne = true; 
                break;
            case "abilityTwo":
                 abilityTwo = true;
                break;
            case "abilityThree":
                 abilityThree = true;
                break;
            
        }
        
    }
    public bool GetAbilityOne()
    {
        return abilityOne;
    }
    public bool GetAbilityTwo()
    {
        return abilityTwo;
    }
    public bool GetAbilityThree()
    {
        return abilityThree;
    }
    public float GetAbilityTimer()
    {
        return Mathf.RoundToInt(timer);
    }

    public bool SetSpreadShot(bool spreads)
    {
        spread = spreads;
        return spread;
    }
}
