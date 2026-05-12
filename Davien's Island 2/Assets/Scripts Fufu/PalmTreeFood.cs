using UnityEngine;

public class PalmTreeFood : MonoBehaviour, IInteractable
{
    public float hungerRestore = 25f;
    public float cooldownTime = 60f;

    private float nextUseTime = 0f;

    public bool CanInteract()
    {
        return Time.time >= nextUseTime;
    }

    public void Interact()
    {
        if (!CanInteract()) return;

        HungerSystem hunger = FindObjectOfType<HungerSystem>();

        if (hunger != null)
        {
            hunger.AddHunger(hungerRestore);
            nextUseTime = Time.time + cooldownTime;
        }
    }
}