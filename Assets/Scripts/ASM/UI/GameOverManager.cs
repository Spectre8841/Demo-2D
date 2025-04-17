using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas;  // Reference to the game over canvas

    private void Start()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;  // Pause the game
    }

    // Call this method to restart the game
    public void RestartGame()
    {
        Time.timeScale = 1f;  // Resume the game
        SceneManager.LoadScene("ASM");  // Reload the current scene
    }
}
