using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveItem : MonoBehaviour
{
    [SerializeField] protected EventEnum eventEnum;
    [SerializeField] protected TaskEnum taskEnum;

    protected void DoTask()
    {
        if (TaskManager.CurrentTask == TaskManager.GetTask(taskEnum))
        {
            EventManager.Invoke(eventEnum);
            TaskManager.GetTask(taskEnum).IsDone = true;
            TaskManager.NextTask();
        }
    }

    public void UndoTask()
    {
        if (TaskManager.CurrentTask == TaskManager.GetTask(TaskEnum.ItsAllDone)) return;

        TaskManager.GetTask(taskEnum).IsDone = false;
        TaskManager.CheckLastUndone();
        if (TaskManager.CurrentTask == TaskManager.GetTask(taskEnum))
        {
            EventManager.Invoke(EventEnum.OnTaskUndone);
        }
    }
}
