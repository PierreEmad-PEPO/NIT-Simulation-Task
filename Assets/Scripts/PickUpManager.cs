using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    private Vector3 raySource;
    private GameObject pickedItem = null;
    private Camera camera;
    [SerializeField] private Transform pickingTransform;
    [SerializeField] private Transform pickingTransformInCamera;
    [SerializeField] private Transform pickingTransformOutCamera;

    public GameObject PickedObject { get {  return pickedItem; } }
    public Transform PickingTransform { get {  return pickingTransform; } }

    // Start is called before the first frame update
    void Start()
    {
        raySource.x = Screen.width / 2;
        raySource.y += Screen.height / 2;
        camera = Camera.main;
        raySource.z = camera.nearClipPlane;

        EventManager.AddListener(EventEnum.OnCameraGetIn, RotateOnCameraIn);
        EventManager.AddListener(EventEnum.OnCameraGetOut, RotateOnCameraOut);
    }

    // Update is called once per frame
    void Update()
    {
        // Pick Up
        if (pickedItem == null && Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(raySource);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Configurations.MaxRayCastDistance) && hit.transform.gameObject.layer != LayerMask.NameToLayer("Wall"))
            {
                if (hit.transform.tag == "Pickable")
                {
                    pickedItem = hit.transform.gameObject;
                    pickedItem.transform.position = pickingTransform.position;
                    pickedItem.transform.rotation = pickingTransform.rotation;
                    pickedItem.transform.parent = camera.transform;
                    pickedItem.GetComponent<Outline>().enabled = false;
                }

            }
        }
        // Drop
        /*
         * Important Note for Raycasting
         * I didn't use LayerMask to ignore Rays but make a hit and ignore it
         * to avoid dropping the item from illegal position
         * */
        else if (pickedItem != null && Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(raySource);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Configurations.MaxRayCastDistance) && hit.transform.gameObject.layer != LayerMask.NameToLayer("Wall")
                && hit.transform.gameObject.layer != LayerMask.NameToLayer("Pickable"))
            {
                Vector3 newPos = hit.point;
                newPos.y += .03f;
                pickedItem.transform.position = newPos;
                pickedItem.transform.rotation = Quaternion.identity;
                pickedItem.transform.parent = null;
                pickedItem.GetComponent<InteractiveItem>().UndoTask();
                if (pickedItem != TaskManager.CurrentTask.TargetObject)
                    pickedItem.GetComponent<HoverEffect>().enabled = true;
                pickedItem = null;
            }
        }
    }

    void RotateOnCameraIn()
    {
        pickingTransform = pickingTransformInCamera;
        if (pickedItem != null) 
        {
            pickedItem.transform.position = pickingTransform.position;
            pickedItem.transform.rotation = pickingTransform.transform.rotation;
        }
    }
    void RotateOnCameraOut()
    {
        pickingTransform = pickingTransformOutCamera;
        if (pickedItem != null)
        {
            pickedItem.transform.position = pickingTransform.position;
            pickedItem.transform.rotation = pickingTransform.transform.rotation;
        }
    }
}
