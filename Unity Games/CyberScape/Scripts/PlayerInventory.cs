using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    [SerializeField] int currentAmmo;
    [SerializeField] int currentHealth;
    [SerializeField] int maxAmmo = 3;
    [SerializeField] Image keyImage;
    [SerializeField] bool hasKey;
    int maxHealth = 100;

    private void Start()
    {
        currentAmmo = maxAmmo;
        currentHealth = maxHealth;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        CheckAmmo();
        CheckHealth();
    }
    void CheckHealth()
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    void CheckAmmo()
    {
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }
    public void AddAmmo(int value)
    {
        currentAmmo += value;
    }

    public int GetAmmo()
    {
        return currentAmmo;
    }
    public void AddHealth(int value)
    {
        currentHealth += value;
    }

    public int GetHealth()
    {
        return currentHealth;
    }
    public void SetKey(bool key, Color col)
    {
        keyImage.color = col;
        hasKey = key;
    }
    public bool GetKey()
    {
        return hasKey;
    }
}
