using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class LogicPolaroid : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    //idk random stuff I need to initialize
    public bool selected;
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    public Image image;
    public Transform parentAfterDrag;
    public int indexAfterDrag;
    public HorizontalPolaroidHolder horizontalPolaroidHolder;
    public bool isBeingUsed;

    // Stuff should we able to see/change
    [Header("Values")]
    [SerializeField] private float dragTransparency;
    [SerializeField] public int ID;
    [SerializeField] public int ableToCombineWithID;
     
    // Initialize events
    [Header("Events")]
    [HideInInspector] public UnityEvent<LogicPolaroid> PointerEnterEvent;
    [HideInInspector] public UnityEvent<LogicPolaroid> PointerExitEvent;
    [HideInInspector] public UnityEvent<LogicPolaroid, bool> PointerUpEvent;
    [HideInInspector] public UnityEvent<LogicPolaroid> PointerDownEvent;
    [HideInInspector] public UnityEvent<LogicPolaroid> BeginDragEvent;
    [HideInInspector] public UnityEvent<LogicPolaroid> EndDragEvent;
    [HideInInspector] public UnityEvent<LogicPolaroid, bool> SelectEvent;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // EFFECTS: Sets polaroid to be on top layer when being dragged
    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDragEvent.Invoke(this);
        canvasGroup.blocksRaycasts = false;
        parentAfterDrag = transform.parent;
        image.raycastTarget = false;
        selected = true;
    }

    // Moves polaroid together with mouse
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    // Honestly this is so jank, but it works and makes it so that the polaroid snaps to
    // the right slot once your let go of it
    public void OnEndDrag(PointerEventData eventData)
    {
        EndDragEvent.Invoke(this);
        canvasGroup.blocksRaycasts = true;
        indexAfterDrag = transform.GetSiblingIndex();
        transform.SetParent(transform.root);
        transform.SetParent(parentAfterDrag);
        transform.SetSiblingIndex(indexAfterDrag);
        image.raycastTarget = true;
        selected = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnterEvent.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExitEvent.Invoke(this);
    }

    // Make polaroid slightly transparent to show it's being dragged
    public void OnPointerDown(PointerEventData eventData)
    {
        PointerDownEvent.Invoke(this);
        canvasGroup.alpha = dragTransparency;
    }

    // Set polaroid back to full transparency
    public void OnPointerUp(PointerEventData eventData)
    {
        SelectEvent.Invoke(this, selected);
        canvasGroup.alpha = 1f;
    }

}
