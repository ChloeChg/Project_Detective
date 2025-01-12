using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldClock : MonoBehaviour, InteractableObject
{
    public Dialogue dialogue; // Reference to the Dialogue system
    public DialogueData dialogueData; // Unique dialogue data for this NPC

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

        // Ensure DialogueData is set and Dialogue system is available
        if (dialogue != null && dialogueData != null)
        {
            dialogue.dialogueData = dialogueData; // Assign this NPC's dialogue data
            dialogue.gameObject.SetActive(true); // Activate the dialogue GameObject
            dialogue.StartDialogue(); // Start the dialogue sequence
        }
        else
        {
            Debug.LogWarning("Dialogue or DialogueData not set for " + transform.name);
        }

        Instantiate(polaroid, new Vector2(0, 0), Quaternion.identity, inventoryMenu.transform);
    }
}
