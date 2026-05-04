using UnityEngine;

public class RaftBuilder : MonoBehaviour
{
    public int logsNeeded = 10;
    private int currentLogs = 0;

    public GameObject completedRaft;

    private bool playerNearby = false;
    private Inventory playerInventory;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            TryBuild();
        }
    }

    void TryBuild()
    {
        if (playerInventory == null) return;

        // 🚨 REQUIRE BLUEPRINT FIRST
        if (!playerInventory.hasBlueprint)
        {
            Debug.Log("You need the blueprint first!");
            return;
        }

        if (playerInventory.RemoveLogs(1))
        {
            currentLogs++;

            Debug.Log("Logs in raft: " + currentLogs + "/" + logsNeeded);

            if (currentLogs >= logsNeeded)
            {
                CompleteRaft();
            }
        }
    }

    void CompleteRaft()
    {
        Debug.Log("Raft Complete!");

        completedRaft.SetActive(true);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            playerInventory = other.GetComponent<Inventory>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}