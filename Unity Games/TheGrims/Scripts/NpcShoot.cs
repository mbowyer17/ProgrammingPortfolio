using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcShoot : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    float shotDelay;
    float timer;
    Animator npcAni;
    // Start is called before the first frame update
    void Start()
    {
        npcAni = this.GetComponent<Animator>();
        shotDelay = Random.Range(0.7f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= shotDelay)
        {
            npcAni.SetTrigger("Shoot");
            Instantiate(bullet, transform.position, Quaternion.identity);
            timer = 0;
            
        }
       

    }
}
