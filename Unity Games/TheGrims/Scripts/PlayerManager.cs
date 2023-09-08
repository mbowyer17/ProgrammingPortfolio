using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour // Use for Customising the Classes
{

    [SerializeField] public string className;
    [SerializeField]Sprite[] modelArray;
    
    SpriteRenderer playerModel;
    
    PlayerInventory inventory;
    PlayerWeapon weapon;
    PlayerController controller;
   
    private void Start()
    {
        
        inventory = GetComponent<PlayerInventory>();
        playerModel = GetComponent<SpriteRenderer>();
        weapon = GetComponent<PlayerWeapon>();
        controller = GetComponent<PlayerController>();
        ChooseClass();

        PlayerPrefs.DeleteKey(className);

        
        
    }
     void ChooseClass()
    {

        if (PlayerPrefs.HasKey("WarriorClass"))
        {
            className = "WarriorClass";
            Warrior();
            

        }
        else if (PlayerPrefs.HasKey("HealerClass"))
        {
            className = "HealerClass";
            Healer();
         
        }
        else if (PlayerPrefs.HasKey("HunterClass"))
        {
            className = "HunterClass";
            Hunter();
          
        }
        else
        {
            print("Fail To Load Class");
        }
        
    }
    void Warrior()
    {
        PlayerClass warrior = new PlayerClass();
        warrior.name = "WarriorClass";
        warrior.health = 2;
        warrior.armor = 5;
        warrior.ammo = 150;
        playerModel.sprite = modelArray[0];

        weapon.SetAbility("abilityThree");
        weapon.SetSpreadShot(false);
        className = warrior.name;
        inventory.SetAmmo(warrior.ammo);
        inventory.SetHealth(warrior.health);
        inventory.SetArmor(warrior.armor);
        inventory.SetMaxHealth(2);
        controller.SetMovSpeed(4.5f);

    }



    void Healer()
    {
        PlayerClass healer = new PlayerClass();
        healer.name = "HealerClass";
        healer.health = 6;
        healer.armor = 2;
        healer.ammo = 150;
        playerModel.sprite = modelArray[1];

        weapon.SetAbility("abilityTwo");
        weapon.SetSpreadShot(false);
        className = healer.name;
        inventory.SetAmmo(healer.ammo);
        inventory.SetHealth(healer.health);
        inventory.SetArmor(healer.armor);
        inventory.SetMaxHealth(6);
        controller.SetMovSpeed(5.5f);

    }

    void Hunter()
    {
        PlayerClass hunter = new PlayerClass();
        hunter.name = "HunterClass";
        hunter.health = 4;
        hunter.armor = 1;
        hunter.ammo = 150;
        playerModel.sprite = modelArray[2];

        weapon.SetAbility("abilityOne");
        weapon.SetSpreadShot(true);
        className = hunter.name;
        inventory.SetAmmo(hunter.ammo);
        inventory.SetHealth(hunter.health);
        inventory.SetArmor(hunter.armor);
        inventory.SetMaxHealth(4);
        controller.SetMovSpeed(4f);

    }


}
