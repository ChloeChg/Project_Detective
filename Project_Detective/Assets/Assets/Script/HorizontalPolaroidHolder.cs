using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HorizontalPolaroidHolder : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private LogicPolaroid selectedPolaroid;

    public List<LogicPolaroid> polaroids;
   

    // Start is called before the first frame update
    void Start()
    {
        polaroids = GetComponentsInChildren<LogicPolaroid>().ToList();

        foreach (LogicPolaroid polaroid in polaroids)
        {
            polaroid.PointerEnterEvent.AddListener(PolaroidPointerEnter);
            polaroid.PointerExitEvent.AddListener(PolaroidPointerExit);
            polaroid.BeginDragEvent.AddListener(BeginDrag);
            polaroid.EndDragEvent.AddListener(EndDrag);
        }
    }

    // REQUIRES: nothing
    // MODIFIES: this
    // EFFECTS: Call this whenever the player acquires a polaroid
    // It adds the polaroid to a list of polaroids (which we need to make swaps)
    // and it also sets up all the events we need (although i lowkey am not sure if they're even necessary lol)
    public void AddPolaroid(LogicPolaroid polaroid)
    {
        polaroids.Add(polaroid);
        polaroid.PointerEnterEvent.AddListener(PolaroidPointerEnter);
        polaroid.PointerExitEvent.AddListener(PolaroidPointerExit);
        polaroid.BeginDragEvent.AddListener(BeginDrag);
        polaroid.EndDragEvent.AddListener(EndDrag);
    }

    // EFFECTS: Whenever a polaroid gets dropped on the polaroid holder, this gets triggered
    // It sets the parent of the polaroid being dragged to be the holder
    public void OnDrop(PointerEventData eventData)
    {
        print("dropped on inventory");
        GameObject dropped = eventData.pointerDrag;
        LogicPolaroid draggableItem = dropped.GetComponent<LogicPolaroid>();
        //polaroids.Add(draggableItem);
        draggableItem.parentAfterDrag = transform;
    }

    // this was part of my attempt to fix the buggy swapping, gonna have to change this a bit later
    // TODO: fix this event so that polaroid gets properly readded to the list without everything exploding
    // EDIT: I FIXED IT LET'S GOOOOOOO
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject polaroid = eventData.pointerDrag;
        LogicPolaroid draggableItem = polaroid.GetComponent<LogicPolaroid>();
        if (!polaroids.Contains(draggableItem)) { polaroids.Add(draggableItem); }
        draggableItem.isBeingUsed = false;
        draggableItem.parentAfterDrag = transform;
        polaroid.transform.SetParent(draggableItem.parentAfterDrag);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject polaroid = eventData.pointerDrag;
        LogicPolaroid draggableItem = polaroid.GetComponent<LogicPolaroid>();
    }

    // EFFECTS: gets triggered when you start dragging a polaroid and assigns that to selectedPolaroid
    void BeginDrag(LogicPolaroid polaroid)
    {
        selectedPolaroid = polaroid;
    }

    // EFFECTS: gets triggered when you stop dragging a polaroid and unassigns selectedPolaroid
    void EndDrag(LogicPolaroid polaroid)
    {
        selectedPolaroid = null;
    }

    // We don't even use hoveredPolaroid, i don't rememeber why I added these two LMAO
    void PolaroidPointerEnter(LogicPolaroid polaroid)
    {

    }

    void PolaroidPointerExit(LogicPolaroid polaroid)
    {

    }

    // Update is called once per frame
    void Update()
    {
        // TODO: FIX SWAPPING, IT'S SLIGHTLY BUGGED
        // When a polaroid gets dragged into the "crafting UI", it needs to get removed from the polaroids list
        // Otherwise the swapping gets buggy because it's trying to account for a polaroid that's not even
        // in the inventory. It also needs to be readded when you drag it back. My first few attempts at this
        // broke the UI btw, so honestly I'm gonna neeed help for this one maybe
        if (selectedPolaroid != null)
        {
            if (!selectedPolaroid.isBeingUsed)
            {
                // Goes through all the polaroids and checks their x pos, and then swaps accordingly if the polaroid
                // you're dragging is no longer in its original position
                for (int i = 0; i < polaroids.Count; i++)
                {

                    if (selectedPolaroid.transform.position.x > polaroids[i].transform.position.x)
                    {
                        if (selectedPolaroid.transform.GetSiblingIndex() < polaroids[i].transform.GetSiblingIndex())
                        {
                            print("swap");
                            Swap(i);
                            break;
                        }
                    }

                    if (selectedPolaroid.transform.position.x < polaroids[i].transform.position.x)
                    {
                        if (selectedPolaroid.transform.GetSiblingIndex() > polaroids[i].transform.GetSiblingIndex())
                        {
                            print("swap");
                            Swap(i);
                            break;
                        }
                    }
                }
            }
        }
    }

    // So basically there's a grid layout group and it automatically sorts the polaroids by their index
    // And so we just change the index to match where you've dragged the polaroid and it swaps them visually
    void Swap(int index)
    {
        int focusedIndex = selectedPolaroid.transform.GetSiblingIndex();
        int crossedIndex = polaroids[index].transform.GetSiblingIndex();

        polaroids[index].transform.SetSiblingIndex(focusedIndex);
        selectedPolaroid.transform.SetSiblingIndex(crossedIndex);
    }
}
