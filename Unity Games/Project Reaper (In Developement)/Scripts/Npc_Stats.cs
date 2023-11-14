using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Npc_Stats", menuName = "ScriptableObjects/Npc_Stats")]
public class Npc_Stats : ScriptableObject
{
    public float health;

    public float maxHealth;

    public float speed;

    public float ai_range;

    public float attack_speed;
    
    public float attack_cooldown;
    
}
