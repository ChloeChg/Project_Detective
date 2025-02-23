using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float movSpeed;
    [SerializeField] private LayerMask layerMask;

    private float speedX, speedY;
    private Vector2 lastDirection;
    private Boolean isWalking = false;
    private Boolean isFacingLeft = true;

    Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    private void HandleInteract() {

        // Kai's code for detecting interactable objects
        if (Input.GetKeyDown(KeyCode.E)) {
            //float distance = 0.3f;
            //RaycastHit2D theObject = Physics2D.Raycast(transform.position, lastDirection, distance, layerMask);
            //// Debug.Log(theObject.collider.gameObject);
            //if (theObject.collider != null) {
            //    InteractableObject interactable = theObject.collider.gameObject.GetComponent<InteractableObject>();
            //    interactable?.Interact();
            //}
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Boolean isInteracting = false;
        if (Input.GetKey(KeyCode.E) && !isInteracting)
        {
            isInteracting = true;
            Debug.Log("interacted");
            if (other.GetComponent<Collider2D>() != null)
            {
                InteractableObject interactable = other.GetComponent<Collider2D>().gameObject.GetComponent<InteractableObject>();
                interactable?.Interact();
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") ;
        speedY = Input.GetAxisRaw("Vertical");
        Vector2 direction = new(speedX, speedY);
        direction = direction.normalized;

        // set walking and left boolean
        isWalking = direction != Vector2.zero;
        isFacingLeft = speedX < 0;
        if (direction != Vector2.zero) {
            lastDirection = direction; // update last direction
        }
        HandleInteract();
        rb.velocity = direction * movSpeed;
    }

    public bool IsWalking() {
        return isWalking;
    }

    public bool IsFacingLeft() {
        return isFacingLeft;
    }
}
