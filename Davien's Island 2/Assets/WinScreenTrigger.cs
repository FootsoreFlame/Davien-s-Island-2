using UnityEngine;

public class CompletedRaftWin : MonoBehaviour, IInteractable
{
    [Header("UI")]
    public GameObject winScreen;

    [Header("Player Controls")]
    public MonoBehaviour playerMovementScript;
    public MonoBehaviour cameraLookScript;

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
        if (winScreen != null)
            winScreen.SetActive(true);

        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        if (cameraLookScript != null)
            cameraLookScript.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }
}