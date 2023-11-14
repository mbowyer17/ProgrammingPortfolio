using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Please optimise for future classses
    /*
     * Switch(ChooseClass)
     * case: Tank
     * break;
     * case: Hunter
     * break;
     * case: Healer
     * break;
     * 
     * 
     * 
     * 
     */

    private void Update()
    {
        if(playerTank.tankStats.currentHealth <= 0)
        {

        }
    }
    [SerializeField] Player_Tank playerTank;
    public void TakeDamage(float damage)
    {
        //damageText.gameObject.transform.localPosition = new Vector3(transform.position.x, .748f);
        //damageText.enabled = true;
        playerTank.tankStats.currentHealth -= damage;
        //damageText.text = damage.ToString();
        
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
