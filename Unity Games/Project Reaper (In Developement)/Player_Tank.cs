using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tank : MonoBehaviour
{
    [SerializeField] public Player_Stats tankStats;

    private void Start()
    {
        tankStats.currentHealth = 100;
        tankStats.maxHealth = 100;
        tankStats.healthRegenRate = 0.2f;
        tankStats.armor = 300;
        tankStats.magicResistance = 5f;
        tankStats.blockChance = 5;
        tankStats.damageReduction = 5;
        tankStats.attackPower = 10;
        tankStats.criticalHitChance = 0.2f;
        tankStats.criticalHitDamage = 30;
        tankStats.attackSpeed = 1f;
        tankStats.speed = 5f;
    }
}
