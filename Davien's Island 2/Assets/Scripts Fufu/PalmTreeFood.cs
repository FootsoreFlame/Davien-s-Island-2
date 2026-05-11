using UnityEngine;

public class PalmTreeFood : MonoBehaviour, IInteractable
{
    public float hungerRestore = 25f;
    public float cooldownTime = 60f;

    private float nextUseTime;

    private HungerSystem hunger;

    void Start()
    {
        hunger = FindObjectOfType<HungerSystem>();
    }

    public void Interact()
    {
        if (Time.time < nextUseTime)
        {
            Debug.Log(gameObject.name + " is on cooldown");
            return;
        }

        if (hunger != null)
        {
            hunger.AddHunger(hungerRestore);

            nextUseTime = Time.time + cooldownTime;

            Debug.Log(gameObject.name + " eaten");
        }
    }
}