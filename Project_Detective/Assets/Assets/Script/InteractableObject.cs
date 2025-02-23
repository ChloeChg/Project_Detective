using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractableObject
{
    public void Interact();

    // How to add dialogue for all NPCs
    // 1. Make a script that extends this interface and add it to the NPC
    // Example:
    // public class exampleNPC : MonoBehaviour, InteractableObject
    //                                                 ^ you need to add this at the end of the class declaration
    //
    // 2. Add the following as fields
    // public Dialogue dialogue; // Reference to the Dialogue system
    // public DialogueData dialogueData; // Unique dialogue data for this NPC
    //
    // 3. Copy the following method and add it
    // public void Interact()
    // {
    //     Debug.Log("My name is " + transform.name);
    // 
    //     // Ensure DialogueData is set and Dialogue system is available
    //     if (dialogue != null && dialogueData != null)
    //     {
    //         dialogue.dialogueData = dialogueData; // Assign this NPC's dialogue data
    //         dialogue.gameObject.SetActive(true); // Activate the dialogue GameObject
    //         dialogue.StartDialogue(); // Start the dialogue sequence
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Dialogue or DialogueData not set for " + transform.name);
    //     }
    // }
    
    // 4. Drag in the DialogueBox game object into the dialogue field in the inpsector for the NPC
    //
    // 5. In the dialogue folder (Assets > Animation > Script > Dialogue)
    //    Create a Dialogue Data by right clicking then going to Create > Dialogue System > Dialogue Data
    //    Dialogue Data are scriptable objects that Kai created to store all the dialogue lines needed in a dialogue interaction
    // 
    // 6. In the Dialogue Data you just created, add all the lines you want for that dialogue interaction
    //
    // 7. Drag this new Dialogue Data you've just created into the dialogueData field in the inpsector of the NPC
    //
    // 8. Add some kind of Collider to the NPC and make sure it isn't a trigger
    //
    // 9. In the inpsector, at the top, set the NPC's layer as "Interactable"
    //
    // 10. You're done! A dialogue box should appear with the dialogue you've made when you interact with the NPC using "e"

}
