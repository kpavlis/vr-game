using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    bool isPaused;

    bool wasCursorVisible;
    CursorLockMode previousLockState;
    float previousTimeScale;


    void Start()
    {
        isPaused = false;
        pauseScreen.SetActive(isPaused);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;

        pauseScreen.SetActive(true);

        wasCursorVisible = Cursor.visible;
        previousLockState = Cursor.lockState;
        previousTimeScale = Time.timeScale;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0f;

       
    }

    public void Resume()
    {
        isPaused = false;

        pauseScreen.SetActive(false);

        Cursor.visible = wasCursorVisible;
        Cursor.lockState = previousLockState;
        Time.timeScale = previousTimeScale;

    }

    public void QuitApp()
    {

        Debug.Log("Quit");
        Application.Quit();
    }
}
