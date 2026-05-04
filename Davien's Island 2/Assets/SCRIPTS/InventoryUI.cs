using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI logText;
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI blueprintText;

    public void UpdateUI(int logs, int maxLogs, bool hasKey, bool hasBlueprint)
    {
        logText.text = "Logs: " + logs + "/" + maxLogs;
        keyText.text = "Key: " + (hasKey ? "✔" : "✘");
        blueprintText.text = "Blueprint: " + (hasBlueprint ? "✔" : "✘");
    }
}