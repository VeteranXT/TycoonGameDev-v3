using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingGrid : MonoBehaviour
{
    private int width;
    private int height;
    private int cellsize;
    private Vector3 gridPosition;
    [SerializeField] private GameObject floorPrefab;
    [SerializeField] private GameObject buildingWall;

    public int GetSize { get { return width * height; } }


    private BuildingGrid[,] buildingGrids;
    private bool[,] hasWallFacing;
    public BuildingGrid(int width, int height, int cellsize, Vector3 position, GameObject floorPrefab, GameObject wall)
    {
        this.width = width;
        this.height = height;
        this.cellsize = cellsize;
        gridPosition = position;
        this.floorPrefab = floorPrefab;
        this.buildingWall = wall;
        buildingGrids = new BuildingGrid[width * cellsize, height * cellsize];
        hasWallFacing = new bool[width * cellsize, height * cellsize];
        GenerateGrid();
    }
    private void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 tilePosition = gridPosition + CalculateCellPosition(x,y);
                GameObject floor = Instantiate(floorPrefab, tilePosition, Quaternion.identity);
                buildingGrids[x,y] = new BuildingGrid(width, height, cellsize, tilePosition, floor, buildingWall);

                CheckAndPlaceWall(x + 1, y, CordinalDirection.RIGHT);
                CheckAndPlaceWall(x - 1, y, CordinalDirection.LEFT);
                CheckAndPlaceWall(x, y - 1, CordinalDirection.DOWN);
                CheckAndPlaceWall(x, y + 1, CordinalDirection.UP);
            }
        }
    }

    private void CheckAndPlaceWall(int x, int y, CordinalDirection direction)
    {
        // Check if the neighboring tile is within the grid bounds
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            hasWallFacing[x,y] = ShouldHaveWallFacing(x, y,direction);
            if(ShouldHaveWallFacing(x, y, direction))
            {
                Vector3 wallPosition = gridPosition + CalculateCellPosition(x, y) + new Vector3(cellsize / 2f, 0f, cellsize / 2f); ;
                Instantiate(buildingWall, wallPosition, Quaternion.Euler(0f, (int)direction * 90f, 0f));
            }  
        }
    }



    private Vector3 CalculateCellPosition(int x, int y)
    {
        return new Vector3(x * cellsize, 0f, y * cellsize);
    }

    private bool ShouldHaveWallFacing(int x, int y, CordinalDirection cordinalDirection)
    {
        switch (cordinalDirection)
        {
            case CordinalDirection.UP:
                return y == 0;
            case CordinalDirection.DOWN:
                return y == height * cellsize - 1;
            case CordinalDirection.LEFT:
                return x == 0;
            case CordinalDirection.RIGHT:
                return x == width * cellsize - 1;
            default:
                return false;
        }
       
    }
}

