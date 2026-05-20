using UnityEngine;

public class CompletedRaft : MonoBehaviour, IInteractable
{
    [Header("UI")]
    public GameObject completeGamePopup;
    public GameObject winScreen;

    [Header("Interaction")]
    public float interactRange = 5f;

    void Start()
    {
        if (completeGamePopup != null)
            completeGamePopup.SetActive(false);

        if (winScreen != null)
            winScreen.SetActive(false);
    }

    void Update()
    {
        CheckHover();
    }

    void CheckHover()
    {
        if (completeGamePopup == null) return;

        Camera cam = Camera.main;
        if (cam == null) return;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            CompletedRaft raft = hit.collider.GetComponentInParent<CompletedRaft>();

            if (raft == this)
            {
                completeGamePopup.SetActive(true);
                return;
            }
        }

        completeGamePopup.SetActive(false);
    }

    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        CompleteGame();
    }

    void CompleteGame()
    {
        if (completeGamePopup != null)
            completeGamePopup.SetActive(false);

        if (winScreen != null)
            winScreen.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }
}