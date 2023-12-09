using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    private string buildingName;
    private BuildingGrid grid;
    private List<Room> rooms = new List<Room>();
    private bool isBought = false;
    private float pricePerSquare = 100f;

    public  Building CreateBuildingInstance(string name,bool isbought, int with, int height,int cellsize, float pricePerSqure, Vector3 BuildingPos, GameObject walls, GameObject Floors)
    {
        Building newBuilding = new Building();
        newBuilding.isBought = isbought;
        newBuilding.rooms = new List<Room>();
        newBuilding.pricePerSquare = pricePerSqure;
        newBuilding.buildingName = name;
        newBuilding.grid = new BuildingGrid(with, height, cellsize, BuildingPos, Floors, walls);
        return null;
    }
    public float GetPriceForBuilding()
    {
        if(grid != null)
        {
            return pricePerSquare * grid.GetSize; 
        }
        return -1;
    }

}
