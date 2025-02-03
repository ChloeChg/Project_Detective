using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class PolaroidCombining : MonoBehaviour, IDropHandler, IPointerExitHandler
{

    public ResultPolaroid resultPolaroid;
    public HorizontalPolaroidHolder horizontalPolaroidHolder;
    public LogicPolaroid currentPolaroid;
    public GameObject currentPolaroidObject;

    [HideInInspector] public UnityEvent<LogicPolaroid> EndDragEvent;

    // TODO: we need a way to check that the two polaroids being combined are correct
    // Not gonna implement this rn because I need to check that we're doing it right
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            // Just the same code in the HorizontalPolaroidHolder that will make the polaroid snap to the slot
            GameObject dropped = eventData.pointerDrag;
            LogicPolaroid logicPolaroid = dropped.GetComponent<LogicPolaroid>();
            if (horizontalPolaroidHolder.polaroids.Contains(logicPolaroid)) { horizontalPolaroidHolder.polaroids.Remove(logicPolaroid); }
            currentPolaroid = logicPolaroid;
            currentPolaroidObject = dropped;
            logicPolaroid.isBeingUsed = true;
            logicPolaroid.parentAfterDrag = transform;
        } 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
