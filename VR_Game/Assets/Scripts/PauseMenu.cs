using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject welcomeScreen;
    public GameObject pauseScreen;
    public GameObject audioSource;
    public GameObject volumeSlider;
    public GameObject player;
    bool isPaused;

    bool wasCursorVisible;
    CursorLockMode previousLockState;
    float previousTimeScale;

    PlayerInput playerInput;

    void Start()
    {
        isPaused = false;
        pauseScreen.SetActive(isPaused);
        playerInput = player.GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!welcomeScreen.activeSelf)
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

        playerInput.DeactivateInput();

    }

    public void Resume()
    {
        isPaused = false;

        pauseScreen.SetActive(false);

        Cursor.visible = wasCursorVisible;
        Cursor.lockState = previousLockState;
        Time.timeScale = previousTimeScale;

        playerInput.ActivateInput();
    }

    public void AdjustVolume()
    {
        audioSource.GetComponent<AudioSource>().volume = volumeSlider.GetComponent<UnityEngine.UI.Slider>().value/100;
    }

    public void QuitApp()
    {

        Debug.Log("Quit");
        Application.Quit();
    }
}
