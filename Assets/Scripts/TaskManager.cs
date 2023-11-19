using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TaskManager
{
    private static List<List<Task>> tasks = new List<List<Task>>();
    private static int pointerRow = 0, pointerCol = 0;
    private static Dictionary<TaskEnum, int> mainTaskOrder = new Dictionary<TaskEnum, int>();
    private static Dictionary<TaskEnum, int> subTaskOrder = new Dictionary<TaskEnum, int>();

    private static Task task;

    public static Task CurrentTask 
    {
        get 
        {
            if (pointerCol < tasks[pointerRow].Count && pointerRow < tasks.Count)
                return tasks[pointerRow][pointerCol];
            int i = tasks.Count - 1;
            int j = tasks[i].Count - 1;
            return tasks[i][j];
        } 
    }

    private static int GetMainTaskOrder(TaskEnum taskEnum)
    {
        int ret = -1;
        mainTaskOrder.TryGetValue(taskEnum, out ret);
        if (ret == -1)
        {
            Debug.LogError("Task isn't in the MainTask Dictoinary");
        }
        return ret;
    }

    private static int GetSubTaskOrder(TaskEnum taskEnum)
    {
        int ret = -1;
        subTaskOrder.TryGetValue(taskEnum, out ret);
        if (ret == -1)
        {
            Debug.LogError("Task isn't in the SubTask Dictoinary");
        }
        return ret;
    }

    public static Task GetTask(TaskEnum taskEnum)
    {
        return tasks[GetMainTaskOrder(taskEnum)][GetSubTaskOrder(taskEnum)];
    }

    // Set the Tasks
    public static void Init()
    {
        // First Sequential Tasks
        tasks.Add(new List<Task>());

        task = new Task(
            "التقط المفك",
            "اذهب الي المفك واضغط عليه بكليك شمال",
            "Staaf");
        tasks[tasks.Count - 1].Add(task);
        mainTaskOrder.Add(TaskEnum.PickTheScrewdriver, tasks.Count - 1);
        subTaskOrder.Add(TaskEnum.PickTheScrewdriver, 0);

        task = new Task(
            "فك البكرة",
            "اذهب الي الثلاجة واضغط علي البكرة بالماوس وزرار A للفك او زرار D للربط",
            "Bakra");
        tasks[tasks.Count - 1].Add(task);
        mainTaskOrder.Add(TaskEnum.DecomposeTheBakra, tasks.Count - 1);
        subTaskOrder.Add(TaskEnum.DecomposeTheBakra, 1);
        //-------------------------------------------------

        // Second Sequential Tasks
        tasks.Add(new List<Task>());

        task = new Task(
            "التقط البنسة",
            "اذهب الي البنسة واضغط عليها بكليك شمال",
            "pliers");
        tasks[tasks.Count-1].Add(task);
        mainTaskOrder.Add(TaskEnum.PickThePliers, tasks.Count-1);
        subTaskOrder.Add(TaskEnum.PickThePliers, 0);

        task = new Task(
            "فك الصامولة",
            "اضغط علي الصامولة واللف بأستخدام A و D للفك او الربط",
            "Nut");
        tasks[tasks.Count - 1].Add(task);
        mainTaskOrder.Add(TaskEnum.DecomposeTheNut, tasks.Count - 1);
        subTaskOrder.Add(TaskEnum.DecomposeTheNut, 1);
        //------------------------------------------------------

        // 3rd Sequential Tasks
        tasks.Add(new List<Task>());

        task = new Task(
            "ركب الصامولة",
            "اضغط علي الصامولة لاعاداتها مكانها ثم قم بربطها بأستخدام البنسة",
            "Nut");
        tasks[tasks.Count - 1].Add(task);
        mainTaskOrder.Add(TaskEnum.ComposeTheNut, tasks.Count - 1);
        subTaskOrder.Add(TaskEnum.ComposeTheNut, 0);

        task = new Task(
            "ركب البكرة",
            "اضغط هلي البكرة لاعادتها مكانها ثم قم بربطها بأستخدام المفك",
            "Bakra");
        tasks[tasks.Count - 1].Add(task);
        mainTaskOrder.Add(TaskEnum.ComposeTheBakra, tasks.Count - 1);
        subTaskOrder.Add(TaskEnum.ComposeTheBakra, 1);
        //---------------------------------------------------------------


        // 4th Sequential Tasks
        tasks.Add(new List<Task>());

        task = new Task(
            "العب براحتك",
            "",
            "");
        tasks[tasks.Count - 1].Add(task);
        mainTaskOrder.Add(TaskEnum.ItsAllDone, tasks.Count - 1);
        subTaskOrder.Add(TaskEnum.ItsAllDone, 0);

    }

    public static void StartTask() 
    {
        if (CurrentTask != GetTask(TaskEnum.ItsAllDone))
        {
            tasks[pointerRow][pointerCol].Activate();
        }
    }

    public static void StopTask()
    {
        tasks[pointerRow][pointerCol].Deactivate();
    }

    public static void NextTask()
    {
        if (CurrentTask.IsDone)
        {
            StopTask();
           
            pointerCol++;
            if (pointerCol == tasks[pointerRow].Count && pointerRow + 1 < tasks.Count)
            {
                pointerRow++;
                pointerCol = 0;
            }

            if (pointerCol < tasks[pointerRow].Count && pointerRow < tasks.Count)
            {
                StartTask();
                CurrentTask.IsDone = false;
            }

            EventManager.Invoke(EventEnum.OnTaskDone);
        }
    }

    public static void CheckLastUndone()
    {
        for (int i = pointerRow; i < tasks.Count; i++) 
        {
            for (int j = 0; j < tasks[i].Count; j++) 
            {
                if (!tasks[i][j].IsDone)
                {
                    StopTask();
                    pointerRow = i;
                    pointerCol = j;
                    StartTask();

                    return;
                }
            }
        }
    }
    
}
