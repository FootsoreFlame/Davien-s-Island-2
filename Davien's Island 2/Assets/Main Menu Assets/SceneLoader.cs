using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Load a scene by name (use this for buttons)
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Optional: directly load your game scene
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene"); // change this to your scene name
    }

    // Optional: quit the game (use for exit button)
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed"); // shows in editor
    }
}