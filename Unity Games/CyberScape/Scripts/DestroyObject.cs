using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] float timer;
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(this.gameObject, timer);
    }


}
