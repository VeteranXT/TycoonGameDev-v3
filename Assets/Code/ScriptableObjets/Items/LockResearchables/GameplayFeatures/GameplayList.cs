using System;
using UnityEngine;

[Serializable]
public class GameplayList
{
    [SerializeField] private string name;
    [SerializeField] private int count;
    [SerializeField] private float DevPoints;
    public float DevelopTimeNeeded { get { return DevPoints; } private set { DevPoints = value; } }
    public string GetFeatureName { get { return name; } private set { name = value; } }

    public int Count { get { return count; } set { count = value; } }


    public void SetCount(int count)
    {
        this.count = count;
    }
}