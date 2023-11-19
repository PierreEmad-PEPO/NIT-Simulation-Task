using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

[System.Serializable]
public class Task
{
    [SerializeField] private string name;
    [SerializeField] private string instruction;
    [SerializeField] private GameObject targetObject;
    private AudioClipName audioClipName;
    private bool isDone;


    public string Name { get { return name; } }
    public string Instruction { get { return instruction; } }
    public GameObject TargetObject { get {  return targetObject; } }
    public AudioClipName AudioClipName { get { return audioClipName; } }
    public bool IsDone { set { isDone = value; } get { return isDone; } }

    public Task(string name, string instruction, string targetObjectName, AudioClipName audioClipName)
    {
        this.name = name;
        this.instruction = instruction;
        this.targetObject = GameObject.Find(targetObjectName);
        if (targetObject == null)
        {
            Debug.LogError("Can't Find Object Named " +  targetObjectName);
        }
        this.audioClipName = audioClipName;
        isDone = false;
    }

    public void Activate()
    {
        targetObject.GetComponent<CurrentTaskHoverEffect>().enabled = true;
    }

    public void Deactivate()
    {
        targetObject.GetComponent<HoverEffect>().enabled = true;
    }
}

public enum TaskEnum
{
    PickTheScrewdriver,
    DecomposeTheBakra,
    PickThePliers,
    DecomposeTheNut,
    ComposeTheNut,
    ComposeTheBakra,
    ItsAllDone
}