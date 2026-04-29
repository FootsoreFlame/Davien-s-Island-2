using UnityEngine;
using UnityEngine.UI;

public class HungerSystem : MonoBehaviour
{
    public float maxHunger = 100f;
    public float currentHunger;

    public float hungerDrainPerSecond = 2f;

    public Slider hungerBar;

    void Start()
    {
        currentHunger = maxHunger;
        UpdateUI();
    }

    void Update()
    {
        currentHunger -= hungerDrainPerSecond * Time.deltaTime;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);

        UpdateUI();
    }

    public void AddHunger(float amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);

        UpdateUI();
    }

    void UpdateUI()
    {
        if (hungerBar != null)
            hungerBar.value = currentHunger / maxHunger;
    }
}