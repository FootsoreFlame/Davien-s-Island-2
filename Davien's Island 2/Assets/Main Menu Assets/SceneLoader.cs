using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    [Header("Gameplay UI")]
    public GameObject gameplayUI;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;

        // Hide gameplay UI at start
        if (gameplayUI != null)
            gameplayUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Turn gameplay UI on
        if (gameplayUI != null)
            gameplayUI.SetActive(true);

        // Hide main menu
        gameObject.SetActive(false);
    }
}