using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private string buildingName;
    [SerializeField] private bool isBought = false;
    [SerializeField] private float buildingPrice;

    [SerializeField] List<Room> rooms;
    public string BuildingName { get { return buildingName; } private set { buildingName = value; } }
    public bool IsBought { get { return isBought; } private set { isBought = value; } }
    public float BuildingPrice { get { return buildingPrice; } private set { buildingPrice = value; } }


    public void SetupData(BuildingsData data, StructureCreation creator)
    {
        this.BuildingName = data.BuildingName;
        this.IsBought = data.IsBought;
        this.buildingPrice = data.BuildingPrice;
        rooms = new List<Room>(); 
    }
}