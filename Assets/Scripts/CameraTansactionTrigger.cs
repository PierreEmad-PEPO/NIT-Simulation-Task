using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTansactionTrigger : MonoBehaviour
{
    private bool IsGotIn = false;
    private bool IsTriggered = false;

    private void Update()
    {
        if (IsTriggered && Input.GetKeyDown(KeyCode.E))
        {
            if (IsGotIn)
            {
                EventManager.Invoke(EventEnum.OnCameraGetOut);
            }
            else
            {
                EventManager.Invoke(EventEnum.OnCameraGetIn);
            }
            IsGotIn = !IsGotIn;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        IsTriggered = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        IsTriggered = false;
    }
}
