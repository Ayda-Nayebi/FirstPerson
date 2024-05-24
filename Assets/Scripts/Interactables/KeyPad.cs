using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Intractable
{
    //this function is where we design our intraction using code.
    protected override void Interact()
    {
        Debug.Log("interacted with " + gameObject.name);
    }
}
