using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldClock : MonoBehaviour, IInteractableObejct
{
    public void Interact()
    {
        Debug.Log("My name is " + transform.name);
    }
}
