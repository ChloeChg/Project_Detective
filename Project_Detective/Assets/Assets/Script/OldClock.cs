using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldClock : MonoBehaviour, IInteractableObejct
{
    public GameObject polaroid;
    public GameObject logicPolaroid;
    public GameObject polaroidInventory;
    public GameObject logicInventory;
    public void Interact()
    {
        Debug.Log("My name is " + transform.name);

        // adds a polaroid to your inventory and logic menu
        Instantiate(polaroid, new Vector2(0, 0), Quaternion.identity, polaroidInventory.transform);
        Instantiate(logicPolaroid, new Vector2(0, 0), Quaternion.identity, logicInventory.transform);
    }
}
