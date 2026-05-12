using UnityEngine;

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
    public GameObject crosshairObject;

    private IInteractable currentInteractable;

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

                if (interactTextObject != null)
                    interactTextObject.SetActive(true);

                if (crosshairObject != null)
                    crosshairObject.SetActive(false);

                return;
            }
        }

        if (interactTextObject != null)
            interactTextObject.SetActive(false);

        if (crosshairObject != null)
            crosshairObject.SetActive(true);
    }
}