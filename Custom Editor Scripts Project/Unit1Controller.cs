using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Unit1Controller : MonoBehaviour
{

    NavMeshAgent agent;
    Vector3 enemyPosition;
    [SerializeField]GameObject[] allEnemies;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        allEnemies = GameObject.FindGameObjectsWithTag("Unit2");
        MoveToEnemy();
        //enemyPosition = GameObject.FindGameObjectWithTag("Unit2").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToEnemy();
        agent.destination = enemyPosition;
        if (allEnemies == null || agent.destination == null)
        {
           
            agent.destination = transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("hELLO");
        if (collision.gameObject.tag == "Unit2")
        {
            print("Hello");
            
            collision.gameObject.SetActive(false);
            
            //enemyPosition = GameObject.FindGameObjectWithTag("Unit2").transform.position;
            MoveToEnemy();
            
        }
//enemyPosition = GameObject.FindGameObjectWithTag("Unit2").transform.position;
        MoveToEnemy();
    }

    private void MoveToEnemy()
    {
        int randnum = Random.Range(0, allEnemies.Length);

        if (allEnemies[randnum].activeSelf == true)
        {
            enemyPosition = allEnemies[randnum].transform.position;
            print(randnum);
        }
    }
}

