using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseClass : MonoBehaviour
{
    public void PickWarrior(string name)
    {
        string className = name;
        // Saving the Input into the Registry editor
        PlayerPrefs.SetString("WarriorClass", className);
        PlayerPrefs.Save();


    }
    public void PickHealer(string name)
    {
        string className = name;
        // Saving the Input into the Registry editor
        PlayerPrefs.SetString("HealerClass", className);
        PlayerPrefs.Save();


    }
    public void PickHunter(string name)
    {
        string className = name;
        // Saving the Input into the Registry editor
        PlayerPrefs.SetString("HunterClass", className);
        PlayerPrefs.Save();


    }
}
