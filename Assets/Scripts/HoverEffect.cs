using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    Outline outline;
    [SerializeField] private Transform playerTransform;

    private void OnEnable()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;

        GetComponent<CurrentTaskHoverEffect>().enabled = false;
    }


    private void OnMouseOver()
    {
        if (outline != null && this.enabled)
        {
            float dist = Vector3.Distance(playerTransform.position, transform.position);
            if (dist < Configurations.MaxRayCastDistance)
            {
                outline.OutlineColor = Color.green;
            }
            else
            {
                outline.OutlineColor = Color.yellow;
            }
        }
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        if (outline != null && this.enabled) 
        {
            outline.enabled = false;
        }
    }

}
