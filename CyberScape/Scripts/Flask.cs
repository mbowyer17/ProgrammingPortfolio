using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask: MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] float flaskForce;
    [SerializeField] GameObject playerCollider;
    [SerializeField] GameObject aoeObject;
    [SerializeField] AudioSource smashAudio;
    void Start()
    {
        
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * flaskForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 10f);
        Physics.IgnoreCollision(this.gameObject.GetComponent<BoxCollider>(), playerCollider.GetComponent<CapsuleCollider>());
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        
        if (collision.gameObject.tag == "Enemy")
        {
            smashAudio.Play();
            Instantiate(aoeObject, transform.position, transform.rotation);
            var damage = collision.gameObject.GetComponent<NpcStats>();
            damage.SetHealth(-1);
            Destroy(gameObject);
        }
        
        
    }
}
