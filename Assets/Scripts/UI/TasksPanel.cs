using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TasksPanel : MonoBehaviour
{
    [SerializeField] private Image taskIcon;
    [SerializeField] private Text taskTitle;
    [SerializeField] private Sprite doneIcon;
    [SerializeField] private Sprite undoneIcon;
    [SerializeField] private GameObject taskToAdd;
    [SerializeField] private GameObject instructionPrefab;
    private GameObject curInstruction;


    private void HandleInstruction(string s)
    {
        Destroy(curInstruction);
        if(s.Length > 0)
        {
            curInstruction = Instantiate(instructionPrefab, transform.parent);
            curInstruction.transform.GetChild(0).GetComponent<Text>().text = s;
        }
    }

    private void AddTask(Task task)
    {
        if (task == null) return;

        taskToAdd = Instantiate(taskToAdd, transform);
        taskIcon = taskToAdd.transform.Find("Icon").GetComponent<Image>();
        taskTitle = taskToAdd.transform.Find("Title").GetComponent<Text>();

        taskTitle.text = task.Name;
        taskIcon.sprite = undoneIcon;
        AudioManager.Play(task.AudioClipName);
        HandleInstruction(task.Instruction);
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddListener(EventEnum.OnTaskDone, NextTask);
        EventManager.AddListener(EventEnum.OnTaskUndone, PreviousTask);

        if (TaskManager.CurrentTask.IsDone == false) 
        {
            AddTask(TaskManager.CurrentTask);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextTask()
    {
        taskIcon.sprite = doneIcon;
        AddTask(TaskManager.CurrentTask);
    }

    void PreviousTask()
    {
        int childCount = transform.childCount;
        if (childCount > 1)
        {
            Destroy(transform.GetChild(childCount - 1).gameObject);

            taskToAdd = transform.GetChild(childCount - 2).gameObject;

            taskIcon = taskToAdd.transform.Find("Icon").GetComponent<Image>();
            taskIcon.sprite = undoneIcon;

            taskTitle = taskToAdd.transform.Find("Title").GetComponent<Text>();
        }
    }
}
