using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public abstract class Intractable : MonoBehaviour
{

    //message display to player when looking at interactable.
    public string promptMessage;

    //this function will be called from player
    public void BaseIntract()
    {
        Interact();
    }


    protected virtual void Interact()
    {
        //this is a template function to be overriden by subclass
    }
}
