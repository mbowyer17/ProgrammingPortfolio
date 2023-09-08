using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Mortis : MonoBehaviour
{
    [SerializeField] private Npc_Controller npcController;
    [SerializeField] private Phases currentPhase;
  
    private float timer;
    [SerializeField] private float shotDelay;
    [SerializeField] GameObject attackPrefab;
    [SerializeField] private GameObject phaseTwoGO;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text bossText;

    public enum Phases
    {
        Phase1, Phase2
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPhase = Phases.Phase1;
        npcController = GetComponent<Npc_Controller>();
        healthBar.maxValue = 1000;
        bossText.text = gameObject.name;
      
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentPhase) { 
            case Phases.Phase1:
                Phase1Mechanics();
                break;
            case Phases.Phase2:
                Phase1Mechanics();
                Phase2Mechanics();
                break;
            default:
                break;
                
        }

        if (npcController.health <= 500)
        {
            print("Next Phase");
            currentPhase = Phases.Phase2;
        }
        healthBar.value = npcController.health;
        print(currentPhase);
    }

    void Phase1Mechanics()
    {
        print("Helloo phase 1");
        Attack();
    }

    public void Attack()
    {
        timer += Time.deltaTime;

        if (timer >= shotDelay)
        {

            Instantiate(attackPrefab, attackPrefab.transform.position, Quaternion.identity);
            timer = 0;

        }

        //Instantiate(attackPrefab, gameObject.transform);
    }

    void Phase2Mechanics()
    {
        print("Helloo phase 2");
        phaseTwoGO.SetActive(true);
    }
}
