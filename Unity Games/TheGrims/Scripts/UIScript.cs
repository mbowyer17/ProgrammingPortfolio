using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIScript : MonoBehaviour
{
    PlayerInventory playerInv;
    PlayerWeapon playerAbil;
    [SerializeField] Text healthText, armorText, ammoText, abilityText;
    [SerializeField] Sprite[] abilityArray;
    [SerializeField] Image ability;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] AudioSource music;
  
    void Update()
    {
        playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        playerAbil = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeapon>();
        healthText.text = "" + playerInv.GetHealth() + "/" +playerInv.GetMaxHealth();
        armorText.text = "" + playerInv.GetArmor();
        ammoText.text = "" + playerInv.GetAmmo();
        abilityText.text = "" + playerAbil.GetAbilityTimer();
        if (playerInv.GetAmmo() > 200)
        {
            ammoText.text = "200";
        }
        if (playerAbil.GetAbilityTimer() < 0)
        {
            abilityText.text = "Right Click!";
        }

        CheckAbility();

        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            music.Pause();
        }
    }

    void CheckAbility()
    {
        if (playerAbil.GetAbilityOne())
        {
            ability.sprite = abilityArray[0];
        }
        else if (playerAbil.GetAbilityTwo())
        {
            ability.sprite = abilityArray[1];

        }
        else if (playerAbil.GetAbilityThree())
        {
            ability.sprite = abilityArray[2];

        }

    }
    public void PickScene(string name)
    {

        SceneManager.LoadScene(name);

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        music.Play();
    }
}
