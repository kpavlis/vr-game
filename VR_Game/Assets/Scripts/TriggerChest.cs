using TMPro;
using UnityEngine;

public class TriggerChest : MonoBehaviour
{
    private Animator mAnimator; //the animator component of the animated object
    public GameObject mText; //the game object that contains the textVariable element
    public GameObject mBackground; //the object which is the background image of the text
    public GameObject main_object; //the animated object
    private TextMeshProUGUI textVariable; //the text element that displays the message to the player


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mAnimator = main_object.GetComponent<Animator>();
        textVariable = mText.GetComponent<TextMeshProUGUI>();
        
    }

    // it is called when a collider enters the trigger area of the object this script is attached to
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mAnimator.SetTrigger("IsHere");
            mBackground.SetActive(true);
            textVariable.color = Color.black;
            textVariable.text = "Congratulations! - You found the treasure. \n Now, explore the rest of the village...";
            mText.SetActive(true);
        }
    }

    // it is called when a collider exits the trigger area of the object this script is attached to
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            mAnimator.SetTrigger("IsAway");
            textVariable.text = "";
            mBackground.SetActive(false);
            textVariable.color = Color.white;
            mText.SetActive(false);
        }
    }
}
