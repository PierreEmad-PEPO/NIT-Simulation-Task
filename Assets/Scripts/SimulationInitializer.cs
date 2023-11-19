using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationInitializer : MonoBehaviour
{

    // This should be Awake to be called before AddListeners
    private void Awake()
    {
        foreach (int EventIndex in Enum.GetValues(typeof(EventEnum)))
        {
            EventManager.AddEvent((EventEnum)EventIndex);
        }
        TaskManager.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        TaskManager.StartTask();
    }
}
