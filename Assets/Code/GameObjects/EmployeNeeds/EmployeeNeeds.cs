using System;
using UnityEngine;

[CreateAssetMenu]
public class EmployeeNeeds  : ScriptableObject
{
    [SerializeField] private string needName;
    [SerializeField] private float currentNeed = 100;
    [SerializeField] private float maxNeed = 100;
    [SerializeField] private float needReducer = 0.1f;
    [SerializeField] private bool isCriticalNeed = false;
    [SerializeField] private NeedFurniture[] objectToFullFillNeed;

    public bool IsCritical { get { return isCriticalNeed; } }
    public float Reducer { get { return needReducer; } }
    public string NeedName { get { return needName; } }

    public bool IsNeededToRefill
    {
        get { return CurrentNeed < 50f; }
    }

    public bool IsCriticalyLow
    {
        get { return CurrentNeed < 10f; }

    }
    public float CurrentNeed { get { return currentNeed; } set {  currentNeed = value; } }

    public float MaxNeed { get { return maxNeed; } set {  maxNeed = value; } }
    public NeedFurniture[] ObjectToFullFillNeed { get { return objectToFullFillNeed; }  }
    public void FullfillNeed()
    {
        CurrentNeed = MaxNeed;
    }
}