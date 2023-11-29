using System.Collections;
using UnityEngine;

public  class NeedFurniture : Furniture
{
    private Employee takenBy = null;
    private EmployeeNeeds fulfillingNeed;
    public EmployeeNeeds GetFullfillingNeed { get {  return fulfillingNeed; }  }
    private void FinishFullfiling()
    {
        takenBy.GoToWorkAfterFullfillNeed();
        takenBy = null;

    }
    public void StartFullfiling(EmployeeNeeds need)
    {
        takenBy.DoNeed(need);

    }


    public bool IsTaken()
    {
        return takenBy != null;
    }

}