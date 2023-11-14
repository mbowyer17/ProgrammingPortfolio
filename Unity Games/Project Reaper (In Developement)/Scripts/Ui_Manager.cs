using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    [SerializeField] private Player_Stats stats;
    [SerializeField] private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Health: " + stats.currentHealth.ToString() + " \n" +
                    "Max Health: " + stats.maxHealth.ToString() + " \n" +
                    "Armor: " + stats.armor.ToString() + " \n" +
                    "Magic res: " + stats.magicResistance.ToString() + " \n" +
                    "Damage Red: " + stats.damageReduction.ToString() + " \n" +
                    "Attack Power: " + stats.attackPower.ToString() + " \n" +
                    "Critical Hit chance: " + stats.criticalHitChance.ToString() + " \n" +
                    "Crit hit damage: " + stats.criticalHitDamage.ToString() + " \n" +
                    "Attack Speed: " + stats.attackSpeed.ToString() + " \n" +
                    "Speed: " + stats.speed.ToString() + " \n";
    }
}
