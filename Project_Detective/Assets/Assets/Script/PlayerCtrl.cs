using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    [SerializeField] private float movSpeed;
    [SerializeField] private LayerMask layerMask;

    private float speedX, speedY;
    private Vector2 lastDirection;

    Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }
    private void HandleInteract() {
        if (Input.GetKeyDown(KeyCode.E)) {
            float distance = 1f;
            RaycastHit2D theObject = Physics2D.Raycast(transform.position, lastDirection, distance, layerMask);
            // Debug.Log(theObject.collider.gameObject);
            if (theObject.collider != null) {
                InteractableObject interactable = theObject.collider.gameObject.GetComponent<InteractableObject>();
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
        if (direction != Vector2.zero) {
            lastDirection = direction; // update last direction
        }
        HandleInteract();
        rb.velocity = direction * movSpeed;
    }
}
