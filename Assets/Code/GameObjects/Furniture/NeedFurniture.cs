using System.Collections;
using UnityEngine;

public  class NeedFurniture : MonoBehaviour
{
    private Employee takenBy = null;
    private EmployeeNeeds fulfillingNeed;
    public EmployeeNeeds GetFullfillingNeed { get {  return fulfillingNeed; }  }
    private void FinishFullfiling()
    {
        takenBy.GoToWorkAfterFullfillNeed();
        takenBy = null;

    }
    public void StartFullfiling()
    {
        takenBy.DoNeed();
    }


    public bool IsTaken()
    {
        return takenBy != null;
    }

}