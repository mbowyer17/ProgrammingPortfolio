using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskWeapon : MonoBehaviour
{
    [SerializeField] GameObject flask;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] Transform flaskSpawnPosition;
    [SerializeField] AudioSource flaskaudio;
    private void Update()
    {
        if (inventory.GetAmmo() > 0 && Input.GetKeyDown(KeyCode.Mouse1))
        {
            print("hello");
            Instantiate(flask, flaskSpawnPosition.position + transform.forward, flaskSpawnPosition.rotation);
            inventory.AddAmmo(-1);
            flaskaudio.Play();
        }
    }


}
