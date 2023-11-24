using UnityEngine;

public class WorkFurniture : MonoBehaviour
{
    private Employee isTaken= null;
    private Transform workSpot;
    
    public Transform GetWorkPosition {  get { return workSpot; } }
    public bool IsTaken {  get{ return isTaken != null; } }

    public void AssignFurniture(Employee employee)
    {
        isTaken = employee;
    }

    public void RemoveFromAssignedFurniture()
    {
        if (IsTaken)
        {
            isTaken = null;
        }
    }
}