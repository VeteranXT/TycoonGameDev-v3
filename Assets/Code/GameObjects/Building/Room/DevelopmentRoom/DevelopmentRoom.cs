using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DevelopmentRoom : Room
{
    private TaskDoDevelopGame currentTask;
    public override void DoTask(Employee taskDone)
    {

    }
    public override void SetupTask(TaskDo task)
    {
        currentTask = (TaskDoDevelopGame)task;
    }
}
