using System;
using UnityEngine;

[Serializable]
public class CustomGrid
{
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private int cellSize;
    private Floor[,] roomGrids;

    public int GetWidth { get {  return gridWidth; } }
    public int GetHeight { get { return gridHeight; } }
    public int GetCellSize { get { return cellSize; } }
    public Floor[,] GetGrid
    {
        get { return roomGrids; }
    }
    public CustomGrid(int gridWidth, int gridHeight, int cellSize)
    {
        this.gridWidth = gridWidth;
        this.gridHeight = gridHeight;
        this.cellSize = cellSize;
        roomGrids = new Floor[gridWidth, gridHeight];
    }
    public CustomGrid(int gridWidth, int gridHeight)
    {
        this.gridWidth = gridWidth;
        this.gridHeight = gridHeight;
        roomGrids = new Floor[gridWidth, gridHeight];
    }
    public void GenerateGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                if (roomGrids[gridWidth, gridHeight] == null)
                {
                    roomGrids[x,y] = new Floor(new Vector3(x* cellSize, 0, y * cellSize));
                }
            }
        }
    }
    public void GenerateAdditionalGrid(int width, int height, int startPosX, int startPosY)
    {
        // Create a new instance of the grid
        CustomGrid newGrid = new CustomGrid(width, height);
        // Generate a new grid
        newGrid.GenerateGrid();
        // Loop through the new grid
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int gridX = startPosX + x;
                int gridY = startPosY + y;

                if (newGrid.roomGrids[x, y] == null)
                {
                    newGrid.roomGrids[x, y] = new Floor(new Vector3(gridX * cellSize, 0, gridY * cellSize));
                }
            }
        }

        // Check if the grids are connected
        if (AreGridsConnected(newGrid))
        {
            // Combine the grids
            CombineGrids(newGrid, startPosX, startPosY);
        }
        else
        {
            //Log it error
        }     
    }

    private bool AreGridsConnected(CustomGrid otherGrid)
    {
        // Check if there's at least one cell from this grid touching another cell from the other grid
        for (int x = 0; x < gridWidth * cellSize; x++)
        {
            for (int y = 0; y < gridHeight * cellSize; y++)
            {
                // Check left side
                if (IsConnectedOnSide(x, y, otherGrid, CardinalDirection.LEFT))
                {
                    return true;
                }

                // Check right side
                if (IsConnectedOnSide(x, y, otherGrid, CardinalDirection.RIGHT))
                {
                    return true;
                }

                // Check top side
                if (IsConnectedOnSide(x, y, otherGrid, CardinalDirection.UP))
                {
                    return true;
                }

                // Check bottom side
                if (IsConnectedOnSide(x, y, otherGrid, CardinalDirection.DOWN))
                {
                    return true;
                }
            }
        }

        return false; // No connected cells found
    }
    private bool IsConnectedOnSide(int x, int y, CustomGrid otherGrid, CardinalDirection direction)
    {
        int targetX = x + (direction == CardinalDirection.LEFT ? -1 : (direction == CardinalDirection.RIGHT ? 1 : 0));
        int targetY = y + (direction == CardinalDirection.UP ? -1 : (direction == CardinalDirection.DOWN ? 1 : 0));

        return targetX >= 0 && targetX < otherGrid.gridWidth * otherGrid.cellSize &&
               targetY >= 0 && targetY < otherGrid.gridHeight * otherGrid.cellSize &&
               roomGrids[x, y] != null && otherGrid.roomGrids[targetX, targetY] != null;
    }
    private void CombineGrids(CustomGrid additionalGrid, int offsetX, int offsetY)
    {
        for (int x = 0; x < additionalGrid.gridWidth * additionalGrid.cellSize; x++)
        {
            for (int y = 0; y < additionalGrid.gridHeight * additionalGrid.cellSize; y++)
            {
                int targetX = offsetX + x;
                int targetY = offsetY + y;

                if (roomGrids[targetX, targetY] == null && additionalGrid.roomGrids[x, y] != null)
                {
                    roomGrids[targetX, targetY] = additionalGrid.roomGrids[x, y];
                }
            }
        }
    }

   



}

