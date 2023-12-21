using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class StructureCreation : MonoBehaviour
{
    private Floor floorPrefab;
    private Wall wallPrefab;
    private Door doorPrefab;
    private int buildingWidth;
    private int buildingHeight;
    private Vector3 buildingPosition;
    private Vector3 doorPosition;
    private int buildingCellSize = 32;
    private CustomGrid grid;
    private Wall[,] walls;
    private Floor[,] floors;
    private Door[,] doors;

    public Door[,] GetDoorGrid { get { return doors; } }
    public Wall[,] GetWallsGrid { get { return walls; } }
    public Floor[,] GetFloorGrid { get { return GetFloorGrid; } }

    public void GenerateBuilding(BuildingsData data)
    {
        grid = new CustomGrid(data.BuildingWidth, data.BuildingHeight);
        grid.GenerateGrid();
        GenerateBuildingRoom();
    }
    private void GenerateBuildingRoom()
    {
        for (int x = 0; x < buildingWidth; x++)
        {
            for (int z = 0; z < buildingHeight; z++)
            {
                if (grid.GetGrid[x, z] == true)
                {
                    CheckAndPlace(x, z, CardinalDirection.UP);
                    CheckAndPlace(x, z, CardinalDirection.DOWN);
                    CheckAndPlace(x, z, CardinalDirection.LEFT);
                    CheckAndPlace(x, z, CardinalDirection.RIGHT);
                }
            }
        }
    }

    private void CheckAndPlace(int x, int z, CardinalDirection direction)
    {
        // Check if the neighboring tile is within the grid bounds
        if (IsInBounds( x,  z))
        {
            //If there is no floors there create it
            if (floors[x, z]  == null)
            {
                Vector3 tilePosition = buildingPosition + CalculateCellPosition(x, z);
                floors[x, z] = Instantiate(floorPrefab, tilePosition, Quaternion.identity);
            }
            //check if here should be part of building
           
            // Check if there's no a Neighbor and its not place for a door place wall
            bool isWall = !HasFloorNeighbor(x, z, direction) && !IsValidDoor(x, z);

            if (isWall)
            {
                //If there is no wall on this position create it
                if (walls[x, z] == null)
                {
                    Vector3 tilePosition = buildingPosition + CalculateCellPosition(x, z);
                    walls[x, z] = Instantiate(wallPrefab, tilePosition, Quaternion.identity);
                }
                //No need to check for something that does not  exist
            }
            //Check if its valid position for door and its should be wall place door
            bool isDoor = IsValidDoor(x,z) && isWall;
            //Check if we need to place a door
            if (isDoor)
            {
                Vector3 tilePosition = buildingPosition + CalculateCellPosition(x, z);
                doors[x, z] = Instantiate(doorPrefab, tilePosition, Quaternion.identity);
            }
          
            if (grid.GetGrid[x, z] == false)
            {
                //If there is floor but no
                if (floors[x, z] != null)
                {
                    Destroy(floors[x, z]);
                }
                //Check if there is wall
                if (walls[x, z] != null)
                {
                    //Destroy it
                    Destroy(walls[x, z]);
                }
                if(doors[x, z] != null) 
                {
                    Destroy(doors[x, z]);
                }

            }
        }
    }

    private bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < buildingWidth && y >= 0 && y < buildingHeight;
    }
    private bool IsValidDoor(int x, int z)
    {
        return doorPosition == new Vector3(x, 0, z);
    }

    private Vector3 CalculateCellPosition(int x, int y)
    {
        return new Vector3(x * buildingCellSize, 0f, y * buildingCellSize);
    }

    private bool HasFloorNeighbor(int x, int y, CardinalDirection cordinalDirection)
    {
        switch (cordinalDirection)
        {
            case CardinalDirection.UP:
                return grid.GetGrid[x, y - 1] == true;
            case CardinalDirection.DOWN:
                return grid.GetGrid[x, y + 1] == true;
            case CardinalDirection.LEFT:
                return grid.GetGrid[x - 1, y] == true; 
            case CardinalDirection.RIGHT:
                return grid.GetGrid[x + 1, y] == true; 
            default:
                return false;
        }
    }
}

