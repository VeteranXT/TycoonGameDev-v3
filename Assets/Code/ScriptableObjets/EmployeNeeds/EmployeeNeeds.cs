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
    [SerializeField] private NeedFurniture[] refullfiliingObjects;

    public bool IsCritical { get { return isCriticalNeed; } }
    public float Reducer { get { return needReducer; } }
    public string NeedName { get { return needName; } }
    public float CurrentNeed { get { return currentNeed; } private set {  currentNeed = value; } }
    public bool IsNeededToRefill  { get { return CurrentNeed < 50f; } }
    public bool IsCriticalyLow {  get { return CurrentNeed < 10f; } }
    public float MaxNeed { get { return maxNeed; } set {  maxNeed = value; } }
    public NeedFurniture[] FullfiliingObjects { get { return refullfiliingObjects; }  }
    public void FullfillNeed()
    {
        CurrentNeed = MaxNeed;
    }

    public void ReuceNeed()
    {
        CurrentNeed -= Reducer;
    }
}