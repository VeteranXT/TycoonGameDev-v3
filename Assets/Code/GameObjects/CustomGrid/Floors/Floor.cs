using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[Serializable]
public class Floor : MonoBehaviour
{
    [SerializeField] private GameObject floorPRefab; 
    private Vector3 floorPos;
    public Vector3 Position { get{ return this.floorPos; } }

    public Floor(Vector3 GetPosition)
    {
        this.floorPos = GetPosition;
    }
}

