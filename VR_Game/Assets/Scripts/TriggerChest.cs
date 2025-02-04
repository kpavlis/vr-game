using TMPro;
using UnityEngine;

public class TriggerChest : MonoBehaviour
{
    private Animator mAnimator;
    public GameObject mText;
    public GameObject mBackground;
    public GameObject main_object;
    private TextMeshProUGUI textVariable;
   


    void Start()
    {
        mAnimator = main_object.GetComponent<Animator>();
        textVariable = mText.GetComponent<TextMeshProUGUI>();
        
    }

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
