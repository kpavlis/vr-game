using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject welcomeScreen; //the object that contains the welcome screen
    public GameObject pauseScreen; //the object that contains the pause screen
    public GameObject audioSource; //the audio source game object
    public GameObject volumeSlider; //the volume slider game object
    public GameObject player; //the player game object
    bool isPaused;

    // cursor and time state variables
    bool wasCursorVisible;
    CursorLockMode previousLockState;
    float previousTimeScale;

    PlayerInput playerInput; //the player input object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPaused = false;
        pauseScreen.SetActive(isPaused);
        playerInput = player.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
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

    // it is called to pause the game and show the pause screen
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

    // it is called to resume the game and hide the pause screen
    public void Resume()
    {
        isPaused = false;

        pauseScreen.SetActive(false);

        Cursor.visible = wasCursorVisible;
        Cursor.lockState = previousLockState;
        Time.timeScale = previousTimeScale;

        playerInput.ActivateInput();
    }

    // it is called when the player adjusts the volume
    public void AdjustVolume()
    {
        audioSource.GetComponent<AudioSource>().volume = volumeSlider.GetComponent<UnityEngine.UI.Slider>().value/100;
    }

    // Perform the quit action
    public void QuitApp()
    {

        Debug.Log("Quit");
        Application.Quit();
    }
}
