using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveClickable : InteractiveItem
{
    private void OnMouseDown()
    {
        DoTask();
    }
}
