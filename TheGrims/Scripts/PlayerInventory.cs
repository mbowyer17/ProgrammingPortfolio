using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int armor;
    [SerializeField] int ammo;

    int maxHealth = 3;
    
    int maxAmmo = 200;

  
    // Encap
    public void AddHealth(int valueToAdd)
    {
        if (health < maxHealth)
        {
            health += valueToAdd;
        }
        
    }
    public void AddArmor(int valueToAdd)
    {
        armor += valueToAdd;
    }
    public void AddAmmo(int valueToAdd)
    {
        if (ammo < maxAmmo)
        {
            ammo += valueToAdd;
        }
        else if (ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }
        else
        {
            ammo += valueToAdd;
        }
        
    }

    public void DamageToPlayer(int valueToAdd)
    {
        
        if (armor <= 0)
        {
            health -= valueToAdd ;
        }
        else
        {
            armor -= valueToAdd;
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetAmmo()
    {
        return ammo;
    }
    public int GetArmor()
    {
        return armor;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public int SetHealth(int hp)
    {
        health = hp;
        return health;
    }

    public int SetAmmo(int am)
    {
        ammo = am;
        return ammo;
    }
    public int SetArmor(int ar)
    {
        armor = ar;
        return armor;
    }
    public int SetMaxHealth(int mxhp)
    {
        maxHealth = mxhp;
        return maxHealth;
    }
}
