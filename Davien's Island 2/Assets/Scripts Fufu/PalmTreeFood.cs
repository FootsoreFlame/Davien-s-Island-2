using UnityEngine;
using System.Collections;

public class PalmTreeFood : MonoBehaviour, IInteractable
{
    public float hungerRestore = 25f;
    public float cooldownTime = 60f;

    private bool canUse = true;

    public void Interact()
    {
        if (!canUse) return;

        HungerSystem hunger = FindObjectOfType<HungerSystem>();

        if (hunger != null)
        {
            hunger.AddHunger(hungerRestore);
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        canUse = false;
        yield return new WaitForSeconds(cooldownTime);
        canUse = true;
    }
}