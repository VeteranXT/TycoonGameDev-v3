using System;
using UnityEngine;

[Serializable]
public class GameplayList
{
    [SerializeField] private int count;
    [SerializeField] private string name;

    [SerializeField] private float DevPoints;
    public float DevelopTimeNeeded { get { return DevPoints; } private set { DevPoints = value; } }

}