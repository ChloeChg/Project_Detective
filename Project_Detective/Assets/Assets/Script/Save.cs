using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private Animation animation;
    void Start()
    {
        animation = GetComponent<Animation>(); 
    }

    void OnMouseEnter()
    {
        if (animation != null)
        {
            animation.Play();
        }
    }
}
