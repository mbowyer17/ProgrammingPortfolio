using UnityEngine;
using UnityEngine.AI;
public class Unit2Controller : MonoBehaviour
{

    NavMeshAgent agent;
    Vector3 enemyPosition;
    int randnum;
    [SerializeField] GameObject[] allEnemies;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        allEnemies = GameObject.FindGameObjectsWithTag("Unit1");
        randnum = Random.Range(0, allEnemies.Length);
        MoveToEnemy();
        //enemyPosition = GameObject.FindGameObjectWithTag("Unit2").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (allEnemies[randnum].activeSelf == true)
        {
            MoveToEnemy();
            DrawPathway();
        }
        else if (allEnemies[randnum].activeSelf == false)
        {
            randnum = Random.Range(0, allEnemies.Length);
            

        }

        
        agent.destination = enemyPosition;
        if (allEnemies == null || agent.destination == null)
        {

            agent.destination = transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("hELLO");
        if (collision.gameObject.tag == "Unit1")
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
       
        enemyPosition = allEnemies[randnum].transform.position;
        print(randnum);
        

    }
    public int GetCurrentTarget()
    {
        return randnum;
    }

    void DrawPathway()
    {
        if (agent.hasPath)
        {
            
                Debug.DrawLine(transform.position, agent.path.corners[1], Color.red);
            
        }
        
    }
}
