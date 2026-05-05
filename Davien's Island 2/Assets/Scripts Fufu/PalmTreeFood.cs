using UnityEngine;

public class PalmTreeFood : MonoBehaviour, IInteractable
{
    public float hungerRestore = 25f;
    public float cooldownTime = 60f;

    private float nextUseTime = 0f;

    public void Interact()
    {
        if (Time.time < nextUseTime)
        {
            Debug.Log("Tree on cooldown");
            return;
        }

        HungerSystem hunger = FindObjectOfType<HungerSystem>();

        if (hunger != null)
        {
            hunger.AddHunger(hungerRestore);
            nextUseTime = Time.time + cooldownTime;
        }
    }
}