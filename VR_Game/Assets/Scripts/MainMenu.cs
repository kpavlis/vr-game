using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] protected GameObject player; //the player game object
    [SerializeField] protected GameObject menuCamera; //the menu camera object
    [SerializeField] protected GameObject controlsScreen; //the object that represents the controls screen
    [SerializeField] protected GameObject mainScreen; //the object that contains the main menu screen elements

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartApp() {

        player.SetActive(true);
        menuCamera.SetActive(false);
        gameObject.SetActive(false); //disable menu
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Show to the user the controls screen
    public void ShowControls()
    {
        controlsScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    // Hide from the user the controls screen
    public void HideControls()
    {
        controlsScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    // Perform the quit action
    public void QuitApp() {

        Debug.Log("Quit");
        Application.Quit();
    }
}
