using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public interface IInteractable
{
    void Interact();
    bool CanInteract();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange = 5f;

    [Header("UI")]
    public GameObject interactTextObject;
    public Text interactText;
    public GameObject crosshairObject;

    private IInteractable currentInteractable;
    private bool interactionUIBlocked = false;

    void Start()
    {
        if (InteractorSource == null)
            InteractorSource = Camera.main.transform;

        if (interactTextObject != null)
            interactTextObject.SetActive(false);

        if (crosshairObject != null)
            crosshairObject.SetActive(true);
    }

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    public void BlockInteractionUI(float duration)
    {
        StartCoroutine(BlockInteractionUICoroutine(duration));
    }

    IEnumerator BlockInteractionUICoroutine(float duration)
    {
        interactionUIBlocked = true;

        if (interactTextObject != null)
            interactTextObject.SetActive(false);

        if (crosshairObject != null)
            crosshairObject.SetActive(false);

        yield return new WaitForSeconds(duration);

        interactionUIBlocked = false;
    }

    void CheckForInteractable()
    {
        currentInteractable = null;

        Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, InteractRange))
        {
            IInteractable interactable =
                hit.collider.GetComponentInParent<IInteractable>();

            if (interactable != null && interactable.CanInteract())
            {
                currentInteractable = interactable;

                if (!interactionUIBlocked)
                {
                    if (interactText != null)
                        interactText.text = "Press E to Interact";

                    if (interactTextObject != null)
                        interactTextObject.SetActive(true);

                    if (crosshairObject != null)
                        crosshairObject.SetActive(false);
                }

                return;
            }
        }

        if (!interactionUIBlocked)
        {
            if (interactTextObject != null)
                interactTextObject.SetActive(false);

            if (crosshairObject != null)
                crosshairObject.SetActive(true);
        }
    }
}