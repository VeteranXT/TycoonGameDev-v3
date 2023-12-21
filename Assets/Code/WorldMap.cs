using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour
{
    [SerializeField] private  List<BuildingsData> buildings = new List<BuildingsData>();
    [SerializeField]  StructureCreation roomCreation;

    private void Start()
    {
        roomCreation = GetComponent<StructureCreation>();
        Setup();
    }

    void Setup()
    {
        for (int i = 0; i < buildings.Count; i++)
        {
           
        }
    }
}

