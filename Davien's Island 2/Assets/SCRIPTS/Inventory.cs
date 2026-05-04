using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Logs")]
    public int logCount = 0;
    public int maxLogs = 10;

    [Header("Key")]
    public bool hasKey = false;

    [Header("Blueprint")]
    public bool hasBlueprint = false;

    public InventoryUI ui;

    void Start()
    {
        ui.UpdateUI(logCount, maxLogs, hasKey, hasBlueprint);
    }

    public void AddLogs(int amount)
    {
        logCount += amount;
        logCount = Mathf.Clamp(logCount, 0, maxLogs);

        ui.UpdateUI(logCount, maxLogs, hasKey, hasBlueprint);
    }

    public bool RemoveLogs(int amount)
    {
        if (logCount >= amount)
        {
            logCount -= amount;
            ui.UpdateUI(logCount, maxLogs, hasKey, hasBlueprint);
            return true;
        }
        return false;
    }

    public void GetKey()
    {
        hasKey = true;
        ui.UpdateUI(logCount, maxLogs, hasKey, hasBlueprint);
    }

    public void GetBlueprint()
    {
        hasBlueprint = true;
        ui.UpdateUI(logCount, maxLogs, hasKey, hasBlueprint);
    }
}