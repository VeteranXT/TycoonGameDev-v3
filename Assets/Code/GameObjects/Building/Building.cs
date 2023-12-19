using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class Building : MonoBehaviour
{
    #region Fields
    [Header("Building General Setup")]
    [Space]
    [SerializeField] private Vector3 buildingPos;
    [SerializeField] private Vector3 doorPosition;
    [SerializeField] private int buildingWidth;
    [SerializeField] private int buildingHeight;
    [SerializeField] private float cellSize;
    [SerializeField] private GameObject floorTilesPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject doorPrefab;
    [SerializeField] private bool isDebugMode = false;
     private Wall[,] hasWalls;
     private Door[,] hasDoor;
    private Floor[,] hasfloor;
    private CustomGrid gridBuilding;
    private bool doorPlaced = false;
    #endregion



    #region Getters
    public Vector3 GetDoorPosition { get { return buildingPos; } }
    public Vector3 GetBuildingPosition { get { return buildingPos; } }
    public int Width { get { return buildingWidth; } }
    public int Height { get { return buildingHeight; } }
    public Floor[,] GetGrid { get { return gridBuilding.GetGrid; } }
    #endregion

    #region Constructors
    private Building(int buildingWidth, int buildingHeight)
    {
        this.buildingWidth = buildingWidth;
        this.buildingHeight = buildingHeight;
    }
    public Building(int buildingWidth, int buildingHeight, int cellSize, Vector3 BuildingPosition,Vector3 DoorPosition, GameObject floorTilesPrefab, GameObject wallprefab)
    {
        this.buildingWidth = buildingWidth;
        this.buildingHeight = buildingHeight;
        this.buildingPos = BuildingPosition;
        this.floorTilesPrefab = floorTilesPrefab;
        this.wallPrefab = wallprefab;
        this.cellSize = cellSize;
        this.doorPosition = DoorPosition;   
        hasWalls = new Wall[buildingWidth, buildingHeight];
        this.transform.position = this.buildingPos;
        gridBuilding = new CustomGrid(buildingWidth, buildingHeight, cellSize);
  
        if(!isDebugMode)
        {
            gridBuilding.GenerateGrid();
            GenerateBuilding();
        }
       
    }

    public void SetDoorPosition(Vector2 position)
    {
        doorPosition = position;
    }
    #endregion
    private void GenerateBuilding()
    {
        for (int x = 0 ; x < this.buildingWidth; x++)
        {
            for(int y = 0 ; y < this.buildingHeight; y++)
            {
                if (!FloorExists(x,y))
                {
                    Vector3 tilePosition = buildingPos + CalculateCellPosition(x, y);
                    hasfloor[x,y] = Instantiate(floorTilesPrefab, tilePosition, Quaternion.identity).GetComponent<Floor>();
                }
                //Check if we are on top of grid
                CheckAndPlace(x, y, CardinalDirection.UP);
                //Check if we are on bottom of grid
                CheckAndPlace(x, y, CardinalDirection.DOWN);
                //Check if we are on edge of left of grid
                CheckAndPlace(x, y, CardinalDirection.LEFT);
                //Check if we are on edge of right of grid
                CheckAndPlace(x, y, CardinalDirection.RIGHT);
                if (hasWalls[x, y] != null && hasDoor[x, y] != null)
                {
                    Destroy(hasWalls[x, y]);
                }
            }
        }
    }
    public void CreateAdditionalSpace(int width, int height, int startX, int startY)
    {
        // Generate additional space in the building floor
        gridBuilding.GenerateAdditionalGrid(width, height, startX, startY);
        // Store the original state of walls
        Wall[,] originalWalls = new Wall[buildingWidth, buildingHeight];
        Array.Copy(hasWalls, originalWalls, hasWalls.Length);
        // Store the original state of single door
        Door[,] originalDoors = new Door[buildingWidth, buildingHeight];
        Array.Copy(hasDoor, originalDoors, hasDoor.Length);

        // Check for intersections and update walls
        for (int x = 0; x < buildingWidth; x++)
        {
            for (int y = 0; y < buildingHeight; y++)
            {
                if (!FloorExists(x, y))
                {
                    Vector3 tilePosition = buildingPos + CalculateCellPosition(x, y);
                    hasfloor[x, y] = Instantiate(floorTilesPrefab, tilePosition, Quaternion.identity).GetComponent<Floor>();
                }
                //Checkl and place walls and doors at correct Locations
                CheckAndPlace(x, y, CardinalDirection.UP);
                CheckAndPlace(x, y, CardinalDirection.DOWN);
                CheckAndPlace(x, y, CardinalDirection.LEFT);
                CheckAndPlace(x, y, CardinalDirection.RIGHT);
                if (originalDoors[x, y] != null && hasDoor[x, y] == null )
                {
                    Destroy(originalDoors[x, y]);
                }
            }
        }
        hasDoor = originalDoors;
        hasWalls = originalWalls;
    }

    #region Private Methods and helpers
    private Vector3 GetCellDoorPosition(int x, int y)
    {
        return buildingPos + CalculateCellPosition(x, y) + new Vector3(cellSize / 2f, 0f, cellSize / 2f);
    }

    private void CheckAndPlace(int x, int y, CardinalDirection direction)
    {
        // Check if the neighboring tile is within the grid bounds
        if (x >= 0 && x < buildingWidth && y >= 0 && y < buildingHeight)
        { // Check if there's no a door at this location and we are at 
          
            //Check if this Tile dose not have neighbor in given direction
            hasWalls[x, y].hasWall = HasFloorNeighbor(x, y, direction);
            //If Neighbor dose not exist in that direction and wall does not exist create wall
            if (!HasFloorNeighbor(x, y, direction) && !hasWalls[x, y].hasWall && !hasWalls[x, y])
            {
                //We get possiton based on grid
                Vector3 wallPosition = buildingPos + CalculateCellPosition(x, y) + new Vector3(cellSize / 2f, 0f, cellSize / 2f); ;
                //We create instance of that 
                hasWalls[x, y] = Instantiate(wallPrefab, wallPosition, Quaternion.Euler(0f, (int)direction * 90f, 0f)).GetComponent<Wall>();
            }
            else
            {
                Destroy(hasWalls[x, y]);
            }
            if (hasDoor[x, y] == null && GetDoorPosition == new Vector3(x, 0, y))
            {
                hasDoor[x, y] = Instantiate(doorPrefab, GetCellDoorPosition(x, y), Quaternion.Euler(0f, (int)direction * 90f, 0f)).GetComponent<Door>();
                doorPlaced = true;
            }
        }
    }
    private bool FloorExists(int x, int y)
    {
        return gridBuilding.GetGrid[x, y] != null;
    }
    private Vector3 CalculateCellPosition(int x, int y)
    {
        return new Vector3(x * cellSize, 0f, y * cellSize);
    }
    private bool HasFloorNeighbor(int x, int y, CardinalDirection cordinalDirection)
    {
        switch (cordinalDirection)
        {
            case CardinalDirection.UP:
               return gridBuilding.GetGrid[x,y -1] != null;
            case CardinalDirection.DOWN:
                return gridBuilding.GetGrid[x, y + 1] != null;
            case CardinalDirection.LEFT:
                return gridBuilding.GetGrid[x - 1, y] != null; ;
            case CardinalDirection.RIGHT:
                return gridBuilding.GetGrid[x + 1, y] != null; ;
            default:
                return false;
        }
    }

    #endregion

}

