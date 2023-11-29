using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Room : MonoBehaviour
{
    private TaskDo currentTask;
    private List<Employee> assingedEmployees = new List<Employee>();
    private event Action EventDoWork;
    public Action GetDoWork {  get{return EventDoWork;} }
    public void DoWork()
    {
        EventDoWork?.Invoke();  
    }
    public TaskDo CurrentTask {  get { return currentTask; } }
    private void Start()
    {
        EventDoWork += DoTask;
    }
    public virtual void DoTask()
    {

    }

  
}