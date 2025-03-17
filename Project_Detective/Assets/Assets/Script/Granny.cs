using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granny : MonoBehaviour, InteractableObject
{
    public GameObject polaroid;
    public GameObject logicPolaroid;
    public GameObject polaroidInventory;
    public GameObject logicInventory;
    public HorizontalPolaroidHolder horizontalPolaroidHolder;

    public Dialogue dialogue; // Reference to the Dialogue system
    public DialogueData dialogueData; // Unique dialogue data for this NPC

    public void Interact()
    {
        if (dialogue != null && dialogueData != null)
        {
            dialogue.dialogueData = dialogueData; // Assign this NPC's dialogue data
            dialogue.gameObject.SetActive(true); // Activate the dialogue GameObject
            dialogue.StartDialogue(); // Start the 
        }
        else
        {
            Debug.LogWarning("Dialogue or DialogueData not set for " + transform.name);
        }

        // This is code for adding a polaroid to the player's inventory
        // We need to refactor this at some point so it's better
        Instantiate(polaroid, new Vector2(0, 0), Quaternion.identity, polaroidInventory.transform);
        GameObject logicPolaroidToAdd = Instantiate(logicPolaroid, new Vector2(0, 0), Quaternion.identity, logicInventory.transform);
        logicPolaroidToAdd.GetComponent<LogicPolaroid>().ID = UnityEngine.Random.Range(1, 4);
        logicPolaroidToAdd.GetComponent<LogicPolaroid>().ableToCombineWithID = UnityEngine.Random.Range(1, 4);
        horizontalPolaroidHolder.AddPolaroid(logicPolaroidToAdd.GetComponent<LogicPolaroid>());
    }
}
