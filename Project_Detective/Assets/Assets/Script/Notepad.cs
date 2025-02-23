using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notepad : MonoBehaviour
{
    private Animation animation;
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void OnMouseEnter()
    {
        if (animation != null)
        {
            animation.Play();
        }
    }
}
