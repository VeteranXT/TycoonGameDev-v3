using UnityEngine;

public class TaskDo : MonoBehaviour 
{
    public virtual void SetTask(TaskDo task)
    {

    }

    protected virtual float GetTotalDevPoints()
    {
        return 1000f;
    }

    public virtual void DoTask(float devPoints)
    {

    }

    
}