using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

[Serializable]
public class BuildingsData
{
    [SerializeField] private int buildingWidth = 5;
    [SerializeField] private int buildingHeight = 5;
    [SerializeField] private Vector3Int doorPosition = new Vector3Int(2,0,0);
    [SerializeField] private CardinalDirection doorDirection = CardinalDirection.UP;
    [SerializeField] private string buildingName;
    [SerializeField] private bool isBought = false;
    [SerializeField] private float buildingPrice;
    [SerializeField] private Vector3 buildingPosition;
    [SerializeField] private Wall wallPrefab;
    [SerializeField] private Floor floorPrefab;
    [SerializeField] private Door doorPrefab;

    public string BuildingName { get { return buildingName; } }
    public bool IsBought { get { return isBought; } }
    public float BuildingPrice { get { return buildingPrice; } }
    public int BuildingWidth { get { return buildingWidth; } }
    public int BuildingHeight { get { return buildingHeight; } }
    public CardinalDirection DoorDirection { get { return doorDirection; } }
    public Vector3Int DoorPosition { get {  return doorPosition; } }
    public Vector3 BuildingPosition { get { return buildingPosition; } }
    public Wall WallPrefab { get {  return wallPrefab; } }
    public Floor FloorPrefab { get {  return floorPrefab; } }
    public Door DoorPrefab { get {  return doorPrefab; } }
}

