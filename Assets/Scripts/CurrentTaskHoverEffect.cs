using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTaskHoverEffect : MonoBehaviour
{
    private Outline outline;
    private float shadingSpeed = -2.0f;

    // Start is called before the first frame update
    void OnEnable()
    {
        outline = GetComponent<Outline>();
        outline.OutlineColor = Color.red;
        outline.enabled = true;

        if (GetComponent<HoverEffect>() != null )
        {
            GetComponent<HoverEffect>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Color color = outline.OutlineColor;
        color.a += shadingSpeed * Time.deltaTime;
        if (color.a <= 0f || color.a >= 1f)
        {
            shadingSpeed *= -1f;
        }
        outline.OutlineColor = color;
    }
}
