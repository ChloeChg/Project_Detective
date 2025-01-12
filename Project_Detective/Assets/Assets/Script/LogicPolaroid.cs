using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogicPolaroid : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    [HideInInspector] public Transform parentAfterDrag;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Sets polaroid to be on top layer when being dragged
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    // Moves polaroid together with mouse
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    // Sets polaroid back to its original layer once done dragging
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.SetParent(parentAfterDrag);
    }

    // Make polaroid slightly transparent to show it's being dragged
    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
    }

    // Set polaroid back to full transparency
    public void OnPointerUp(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
    }
}
