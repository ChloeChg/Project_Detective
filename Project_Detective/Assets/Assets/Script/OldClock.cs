using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldClock : MonoBehaviour, InteractableObject
{
    public GameObject polaroid;
    public GameObject logicPolaroid;
    public GameObject polaroidInventory;
    public GameObject logicInventory;
    public HorizontalPolaroidHolder horizontalPolaroidHolder;
    public void Interact()
    {
        Debug.Log("My name is " + transform.name);

        // adds a polaroid to your inventory and logic menu
        // TODO: WE NEED TO CHANGE AND MOVE ALL OF THIS CODE
        // 1. We need a general script for interaction with objects
        // 2. We need to make a better system for giving polaroids, the clocks just give you one every time you press it
        //    - Polaroids need to store an ID, name, hint, description, the polaroid(s) it can be combined with, and image probably or smt like that
        //    - We either need to revamp how polaroids or stored, or we just need to make sure that polaroids get properly added
        //    - There are technically 2 kinds of polaroids rn, the bag polaroids, and the logic polaroids
        //    - The bag polaroids literally have no code, they're just visual to show that you've actually collected a polaroid
        //    - The logic polaroids are what I've been working
        // 3. We need to make sure that the implementation properly adds polaroids so we kinda need some discussion/planning on how
        //    it should all work
        Instantiate(polaroid, new Vector2(0, 0), Quaternion.identity, polaroidInventory.transform);
        GameObject logicPolaroidToAdd = Instantiate(logicPolaroid, new Vector2(0, 0), Quaternion.identity, logicInventory.transform);
        logicPolaroidToAdd.GetComponent<LogicPolaroid>().ID = UnityEngine.Random.Range(1, 4);
        logicPolaroidToAdd.GetComponent<LogicPolaroid>().ableToCombineWithID = UnityEngine.Random.Range(1, 4);
        horizontalPolaroidHolder.AddPolaroid(logicPolaroidToAdd.GetComponent<LogicPolaroid>());
    }
}
