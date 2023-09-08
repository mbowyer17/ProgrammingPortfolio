using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        this.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
        Physics2D.IgnoreCollision(playerTransform.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<CircleCollider2D>());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
