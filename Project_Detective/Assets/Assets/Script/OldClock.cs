using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldClock : MonoBehaviour, IInteractableObejct
{
    public GameObject polaroid;
    public GameObject inventoryMenu;
    public void Interact()
    {
        Debug.Log("My name is " + transform.name);
        Instantiate(polaroid, new Vector2(0, 0), Quaternion.identity, inventoryMenu.transform);
    }
}
