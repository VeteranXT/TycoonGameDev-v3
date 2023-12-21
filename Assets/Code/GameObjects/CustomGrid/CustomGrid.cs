using System;
using UnityEngine;

[Serializable]
public class CustomGrid
{
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private int cellSize;
    private bool[,] roomGrids;

    public int GetWidth { get {  return gridWidth; } }
    public int GetHeight { get { return gridHeight; } }
    public int GetCellSize { get { return cellSize; } }
    public bool[,] GetGrid
    {
        get { return roomGrids; }
        private set {  roomGrids = value; }
    }
    public CustomGrid(int gridWidth, int gridHeight, int cellSize = 32)
    {
        this.gridWidth = gridWidth;
        this.gridHeight = gridHeight;
        this.cellSize = cellSize;
        roomGrids = new bool[gridWidth, gridHeight];
        GenerateGrid();
    }
    public void GenerateGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                roomGrids[x, y] = true;
            }
        }
    }
    public void GenerateAdditionalGrid(int width, int height, int startPosX, int startPosY)
    {
        // Create a new instance of the grid
        CustomGrid newGrid = new CustomGrid(gridWidth + width, gridHeight + height);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int gridX = startPosX + x;
                int gridY = startPosY + y;

                if (gridX >= 0 && gridX < gridWidth && gridY >= 0 && gridY < gridHeight && roomGrids[gridX, gridY] == false)
                {
                    newGrid.roomGrids[gridX, gridY] = true;
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
            // Log an error or handle the situation where grids are not connected
            Debug.LogError("Generated grids are not connected.");
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
               roomGrids[x, y] == true && otherGrid.roomGrids[targetX, targetY] == true;
    }
    private void CombineGrids(CustomGrid additionalGrid, int offsetX, int offsetY)
    {
        for (int x = 0; x < additionalGrid.gridWidth * additionalGrid.cellSize; x++)
        {
            for (int y = 0; y < additionalGrid.gridHeight * additionalGrid.cellSize; y++)
            {
                int targetX = offsetX + x;
                int targetY = offsetY + y;

                //Check for other grid that extended its borders bounds
                if (roomGrids[targetX, targetY] == false && additionalGrid.roomGrids[x, y] == true)
                {
                    roomGrids[targetX, targetY] = additionalGrid.roomGrids[x, y];
                }
            }
        }
    }
}

