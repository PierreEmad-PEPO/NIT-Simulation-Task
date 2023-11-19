using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSlider : InteractiveItem
{
    [SerializeField] private EventEnum eventEnumUp;
    [SerializeField] private TaskEnum taskEnumUp;

    [SerializeField, Range(0f, 200f)] private float degreesLeft = 180f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject requiredTool;
    [SerializeField] private Vector3 rotateDirection;
    [SerializeField] private Transform requiredToolTransform;
    
    private Animator animator;
    [SerializeField] private string taskDownAnimation;
    [SerializeField] private string taskUpAnimation;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnMouseDrag()
    {
        if (player.GetComponent<PickUpManager>().PickedObject != requiredTool) return;

        player.DisableMovement();
        float degrees = Input.GetAxis("Horizontal") * speed;

        if (degreesLeft <= 0)
        {
            animator.Play(taskDownAnimation);
            DoTask();
        }
        else if (degreesLeft >= 200)
        {
            DoTaskUp();
        }
        else
        {
            requiredTool.transform.Rotate(rotateDirection * degrees);
        }

        degreesLeft += degrees;
        degreesLeft = Mathf.Clamp(degreesLeft, 0f, 200f);
    }

    private void OnMouseDown()
    {
        if (degreesLeft <= 0)
        {
            animator.Play(taskUpAnimation);
            degreesLeft = 5f;
        }
        else
        {
            if (player.GetComponent<PickUpManager>().PickedObject == requiredTool)
            {
                requiredTool.transform.position = requiredToolTransform.position;
                requiredTool.transform.rotation = requiredToolTransform.rotation;
            }
        }
    }

    private void OnMouseUp()
    {
        if (Camera.main.GetComponent<CameraTransactions>().IsGettingIn == false)
            player.EnableMovement();

        if (player.GetComponent<PickUpManager>().PickedObject == requiredTool)
        {
            requiredTool.transform.position = player.GetComponent<PickUpManager>().PickingTransform.position;
            requiredTool.transform.rotation = player.GetComponent<PickUpManager>().PickingTransform.rotation;
        }

    }

    private void DoTaskUp()
    {
        EventManager.Invoke(eventEnumUp);
        TaskManager.GetTask(taskEnumUp).IsDone = true;
        TaskManager.NextTask();
    }
}
