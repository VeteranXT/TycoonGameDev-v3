using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Room : MonoBehaviour
{
    private TaskDo currentTask;
    private List<Employee> assingedEmployees = new List<Employee>();

    public TaskDo CurrentTask {  get { return currentTask; } }
    private void Start()
    {
      
    }
    public virtual void DoTask()
    {

    }
    public virtual void Update()
    {
        //We have task do not anything
        if(currentTask != null)
        {
            return;
        }
    }


}