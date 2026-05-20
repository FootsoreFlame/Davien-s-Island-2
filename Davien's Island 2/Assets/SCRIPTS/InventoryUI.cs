using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("UI Text")]
    public TextMeshProUGUI logText;
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI blueprintText;

    [Header("Inventory")]
    public int logs = 0;
    public int maxLogs = 10;

    public bool hasKey = false;
    public bool hasBlueprint = false;

    private int totalLogsCollected = 0;
    private int lastLogs = 0;

    void Start()
    {
        UpdateUI();
    }

    public void AddLogs(int amount)
    {
        logs += amount;
        logs = Mathf.Clamp(logs, 0, maxLogs);

        UpdateUI();
    }

    public bool RemoveLogs(int amount)
    {
        if (logs >= amount)
        {
            logs -= amount;
            UpdateUI();
            return true;
        }

        return false;
    }

    public void GetKey()
    {
        hasKey = true;
        UpdateUI();
    }

    public void GetBlueprint()
    {
        hasBlueprint = true;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (logs > lastLogs)
        {
            totalLogsCollected += logs - lastLogs;
        }

        lastLogs = logs;

        logText.text = "Logs: " + totalLogsCollected + "/" + maxLogs;
        keyText.text = "Key: " + (hasKey ? "Collected" : "Not Collected");
        blueprintText.text = "Blueprint: " + (hasBlueprint ? "Collected" : "Not Collected");
    }
}