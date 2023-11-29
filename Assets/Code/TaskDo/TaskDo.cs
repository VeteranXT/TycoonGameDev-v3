using UnityEngine;

public class TaskDo : MonoBehaviour 
{
    public virtual void SetTask(TaskDo task)
    {

    }

    protected virtual float GetTotalDevPoints()
    {
        return 0f;
    }

    public virtual void AddDevPoints(float devPoints)
    {

    }

    
}