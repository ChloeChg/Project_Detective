using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatNPC : MonoBehaviour, InteractableObject
{
    public Dialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        ///nothin 
    }

    public void Interact()
    {
        Debug.Log("My name is " + transform.name);
        // Start the dialogue
        if (dialogue != null)
        {
            dialogue.gameObject.SetActive(true); // Make sure the dialogue GameObject is active
            dialogue.StartDialogue(); // Start the dialogue sequence
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
