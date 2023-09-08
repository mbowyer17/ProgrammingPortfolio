using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    [SerializeField] Slider slider, cooldownSlider;
    [SerializeField] PlayerInventory playerHealth;
    [SerializeField] GrappleWeapon grappleCooldown;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject player, gameManager;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        slider.minValue = 0;
        slider.maxValue = 100;
        cooldownSlider.enabled = false;
        pauseMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        slider.value = playerHealth.GetHealth();
        if (grappleCooldown.GetCooldown() <= 0)
        {
            cooldownSlider.gameObject.SetActive(false);
        }
        else if (grappleCooldown.GetCooldown() > 0)
        {
            cooldownSlider.gameObject.SetActive(true);
            cooldownSlider.value = grappleCooldown.GetCooldown();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            player.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MuteSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void ExitGame()
    {
        Destroy(player);
        Destroy(gameManager);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Destroy(this.gameObject);
        
        
    }
}
