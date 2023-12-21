using System;
using TMPro;
using UnityEngine;

[Serializable]
public class CustomGrid
{
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private int cellSize;
    [SerializeField] int cardinalDirectionSides = Enum.GetValues(typeof(CardinalDirection)).Length;
    private Cell[,,] roomGrids;
    public int GetWidth { get {  return gridWidth; } }
    public int GetHeight { get { return gridHeight; } }
    public int GetCellSize { get { return cellSize; } }
    public Cell[,,] GetGrid
    {
        get { return roomGrids; }
        private set {  roomGrids = value; }
    }
    public CustomGrid(int gridWidth, int gridHeight, int cellSize = 32)
    {
        this.gridWidth = gridWidth;
        this.gridHeight = gridHeight;
        this.cellSize = cellSize;
        roomGrids = new Cell[gridWidth, gridHeight, cardinalDirectionSides];
        GenerateGrid();
    }
    private void GenerateGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                for (int z = 0; z < cardinalDirectionSides; z++)
                {
                    roomGrids[x, y,z] = new Cell();
                }
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
                for (int z = 0; z < cardinalDirectionSides; z++)
                {
                    int gridX = startPosX + x;
                    int gridY = startPosY + y;

                    if (gridX >= 0 && gridX < gridWidth && gridY >= 0 && gridY < gridHeight && roomGrids[gridX, gridY,z] != null)
                    {
                        newGrid.roomGrids[gridX, gridY,z] = new Cell();
                    }
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
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
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

        return targetX >= 0 && targetX < otherGrid.gridWidth  &&
               targetY >= 0 && targetY < otherGrid.gridHeight &&
               roomGrids[x, y, (int)direction] != null && otherGrid.roomGrids[targetX, targetY,(int)direction] != null;
    }
    private void CombineGrids(CustomGrid additionalGrid, int offsetX, int offsetY)
    {
        for (int x = 0; x < additionalGrid.gridWidth; x++)
        {
            for (int y = 0; y < additionalGrid.gridHeight; y++)
            {
                for (int z = 0; z < cardinalDirectionSides; z++)
                {
                    int targetX = offsetX + x;
                    int targetY = offsetY + y;

                    //Check for other grid that extended its borders bounds
                    if (roomGrids[targetX, targetY,z] == null && additionalGrid.roomGrids[x, y,z] != null)
                    {
                        roomGrids[targetX, targetY,z] = additionalGrid.roomGrids[x, y,z];
                    }
                }
            }

        }
    }
  
}

