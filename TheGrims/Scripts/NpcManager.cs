using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    NpcHealth currentHealth;
    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = this.gameObject.GetComponent<NpcHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth.healthAmount <= 0)
        {

            isDead = true;
            KillNpc();
        }
    }

    void KillNpc()
    {
        if (isDead)
        {
            Destroy(this.gameObject);
        }
       
    }
}
