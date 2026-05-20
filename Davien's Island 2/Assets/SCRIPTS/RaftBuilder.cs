using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RaftBuilder : MonoBehaviour, IInteractable
{
    public int logsNeeded = 10;
    private int currentLogs = 0;

    public GameObject completedRaft;

    [Header("Blueprint Popup")]
    public GameObject needBlueprintPopup;
    public float blueprintPopupTime = 2f;

    [Header("Logs Popup")]
    public GameObject logsPopup;
    public float logsPopupTime = 2f;

    private Text logsText;
    private InventoryUI playerInventory;

    void Start()
    {
        playerInventory = FindObjectOfType<InventoryUI>();

        if (completedRaft != null)
            completedRaft.SetActive(false);

        if (needBlueprintPopup != null)
            needBlueprintPopup.SetActive(false);

        if (logsPopup != null)
        {
            logsText = logsPopup.GetComponentInChildren<Text>(true);
            logsPopup.SetActive(false);
        }
    }

    public bool CanInteract()
    {
        return currentLogs < logsNeeded;
    }

    public void Interact()
    {
        TryBuild();
    }

    void TryBuild()
    {
        if (playerInventory == null) return;

        if (!playerInventory.hasBlueprint)
        {
            StartCoroutine(ShowBlueprintPopup());
            return;
        }

        if (playerInventory.RemoveLogs(1))
        {
            currentLogs++;

            StartCoroutine(ShowLogsPopup());

            if (currentLogs >= logsNeeded)
            {
                CompleteRaft();
            }
        }
    }

    IEnumerator ShowBlueprintPopup()
    {
        Interactor interactor = FindObjectOfType<Interactor>();

        if (interactor != null)
            interactor.BlockInteractionUI(blueprintPopupTime);

        if (needBlueprintPopup != null)
            needBlueprintPopup.SetActive(true);

        yield return new WaitForSeconds(blueprintPopupTime);

        if (needBlueprintPopup != null)
            needBlueprintPopup.SetActive(false);
    }

    IEnumerator ShowLogsPopup()
    {
        Interactor interactor = FindObjectOfType<Interactor>();

        if (interactor != null)
            interactor.BlockInteractionUI(logsPopupTime);

        if (logsPopup != null)
            logsPopup.SetActive(true);

        if (logsText == null && logsPopup != null)
            logsText = logsPopup.GetComponentInChildren<Text>(true);

        if (logsText != null)
            logsText.text = "Logs Submitted: " + currentLogs + " / " + logsNeeded;

        yield return new WaitForSeconds(logsPopupTime);

        if (logsPopup != null)
            logsPopup.SetActive(false);
    }

    void CompleteRaft()
    {
        Debug.Log("Raft Complete!");

        // Hide logs popup
        if (logsPopup != null)
            logsPopup.SetActive(false);

        // Show completed raft
        if (completedRaft != null)
            completedRaft.SetActive(true);

        // Disable schematic/build raft
        gameObject.SetActive(false);
    }
}