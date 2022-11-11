using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    private static bool _gameIsPaused = false;

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            _gameIsPaused = !_gameIsPaused;
            PauseManager();
        }
    }

    private void PauseManager() {
        if (_gameIsPaused)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ResumeButton() {
        _gameIsPaused = false;
        PauseManager();
    }

    public void MainMenuButton() {
        _gameIsPaused = false;
        PauseManager();
        SceneManager.LoadScene(0);
    }
}
