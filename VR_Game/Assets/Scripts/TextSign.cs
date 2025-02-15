using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSign : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject indicator; //indicator that helps to show that object is interactable

    [TextArea(3, 10)] public string text; //the text that will be displayed when interacted


    public void OnInteract(Interactor interactor)
    {

        indicator.SetActive(false); //hide

        //call interactor's public method ReceiveInteract
        //...with override method that gets a string as a parameter

        interactor.ReceiveInteract(text);

    }


    //unimplemented Methods

    public void OnEndInteract()
    {

    }


    public void OnAbortInteract()
    {

        indicator.SetActive(false); //hide

    }


    public void OnReadyInteract()
    {

        indicator.SetActive(true); //show

    }
}
