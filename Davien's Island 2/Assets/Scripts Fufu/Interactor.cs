using UnityEngine;

public interface IInteractable
{
    void Interact();
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

        Ray ray = new Ray(
            InteractorSource.position,
            InteractorSource.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit, InteractRange))
        {
            IInteractable interactable =
                hit.collider.GetComponentInParent<IInteractable>();

            if (interactable != null)
            {
                currentInteractable = interactable;

                // Show interact text
                if (interactTextObject != null)
                    interactTextObject.SetActive(true);

                // Hide crosshair
                if (crosshairObject != null)
                    crosshairObject.SetActive(false);

                return;
            }
        }

        // Hide interact text
        if (interactTextObject != null)
            interactTextObject.SetActive(false);

        // Show crosshair again
        if (crosshairObject != null)
            crosshairObject.SetActive(true);
    }
}