using UnityEngine;

public class RoomChangerScript : MonoBehaviour
{
    [SerializeField] GameObject[] listOfNpcs;
    public GameObject[] roomRewardGO;
    [SerializeField] private GameObject rewardSpawnPosition;
    private bool hasSpawnedReward = false; // Add this variable to track if the reward has already been spawned
    [SerializeField] private bool allDestroyed; 

    private void Update()
    {
        if (listOfNpcs != null && listOfNpcs.Length > 0)
        {
            allDestroyed = true;

            foreach (GameObject npc in listOfNpcs)
            {
                if (npc != null)
                {
                    allDestroyed = false;
                    break;
                }
            }

            if (allDestroyed)
            {
                OnAllNpcsDestroyed();

            }
        }
    }

  

    private void OnAllNpcsDestroyed()
    {
        if (!hasSpawnedReward) // Check if the reward hasn't been spawned yet
        {
            print("Completed Room");

            if (roomRewardGO.Length > 0)
            {
                int randomNum = Random.Range(0, roomRewardGO.Length);
                print(randomNum);

                Instantiate(roomRewardGO[randomNum], rewardSpawnPosition.transform);
            }

            hasSpawnedReward = true; // Mark that the reward has been spawned
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject npc in listOfNpcs)
            {
                if (npc != null)
                {
                    npc.SetActive(true);
                }
            }
        }
    }
}

