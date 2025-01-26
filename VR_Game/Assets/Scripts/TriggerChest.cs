using TMPro;
using UnityEngine;

public class TriggerChest : MonoBehaviour
{
    public GameObject mText;
    public GameObject mBackground;
    private TextMeshProUGUI textVariable;
    private Animator mAnimator;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        textVariable = mText.GetComponent<TextMeshProUGUI>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mAnimator.SetTrigger("IsHere");
            mBackground.SetActive(true);
            textVariable.color = Color.black;
            textVariable.text = "Καλωσήρθες στον θησαυρό ! Ανακάλυψε τα μυστικά...";
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
