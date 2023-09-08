using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player_Stats", menuName ="ScriptableObjects/Player_Stats")]
public class Player_Stats : ScriptableObject
{
   
    public float maxHealth;

    public float currentHealth;

    public float healthRegenRate;


    public float armor;

    public float magicResistance;

    public float blockChance;

    public float damageReduction;

 
    public float attackPower;

    public float criticalHitChance;

    public float criticalHitDamage;
    
    public float attackSpeed;

    public float speed;
    
  
}
