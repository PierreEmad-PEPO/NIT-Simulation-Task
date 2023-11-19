using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransactions : MonoBehaviour
{
    [SerializeField] private Transform GettingInTransform;
    [SerializeField] private Transform GettingOutTransform;
    private bool isGettingIn = false;
    private float speed = 5.0f;

    public bool IsGettingIn {  get { return isGettingIn; } }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddListener(EventEnum.OnCameraGetIn, GetIn);
        EventManager.AddListener(EventEnum.OnCameraGetOut, GetOut);
    }

    void Update()
    {
        if (isGettingIn && Vector3.Distance(transform.position, GettingInTransform.position) > 0.0001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, GettingInTransform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, GettingInTransform.rotation, speed * Time.deltaTime);
        }
        else if (!isGettingIn && Vector3.Distance(transform.position, GettingOutTransform.position) > 0.0001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, GettingOutTransform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, GettingOutTransform.rotation, speed * Time.deltaTime);
        }
    }

    void GetIn()
    {
        isGettingIn = true;
    }
    void GetOut()
    {
        isGettingIn = false;
    }
}
