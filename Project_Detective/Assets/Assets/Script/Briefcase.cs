using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Briefcase : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseEnter()
    {
        if (animator != null)
        {
            animator.SetTrigger("PlayBriefcase");
        }
    }
}