using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class TaskDoDevelopGame : TaskDo
{
    private GameInDevelopment taskDevelopGame;
    private float pointsAccumulated = 0;
    public TaskDoDevelopGame CreateInstance (GameInDevelopment newGame)
    {
        GameObject obj = new GameObject();
        obj.AddComponent<TaskDoDevelopGame>();
        TaskDoDevelopGame newTask = obj.GetComponent<TaskDoDevelopGame>();
        //Create new task and assign it to room task.
        newTask.taskDevelopGame = newGame;
        newTask.taskDevelopGame.EventDevelopmentFinished += DevelopmentFinished;
        return newTask;
    }
    public override void DoTask(float devPoints)
    {
        if(taskDevelopGame != null)
        {
            if (!taskDevelopGame.IsDevelopmentFinished)
            {
                taskDevelopGame.AddDevPoints(devPoints);
            }
        }
        base.DoTask(devPoints);
    }
    private void DevelopmentFinished(GameInDevelopment taskFinished)
    {
        //TO DO: Whem game is finished ask player to publish
        //TO DO: Ask to continue (polish game)
        //TO DO: Store Game for later date to be released.
    }


}





