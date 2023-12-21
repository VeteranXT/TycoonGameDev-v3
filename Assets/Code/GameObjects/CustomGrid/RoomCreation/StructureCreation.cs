


using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;

public class StructureCreation : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public GameObject doorPrefab;
    public int gridWidth = 5;
    public int gridHeight = 5;
    public CustomGrid grid;

    public Cell[,,] GetCusotmGrid { get { return grid.GetGrid; } }
    public Building CreateBuilding (BuildingsData data)
    {
        grid = new CustomGrid(data.BuildingWidth, data.BuildingHeight);
        GameObject Building = new GameObject();

        Building b= Building.AddComponent<Building>().GetComponent<Building>();
        b.SetupData(data);
        b.transform.parent = null;
        GenerateBuilding().transform.parent = Building.transform;
        return b;
    }
    private GameObject GenerateBuilding()
    {
        GameObject Building = new GameObject("Building");
        GameObject flpors = new GameObject("Floor Parent");
        flpors.transform.parent = Building.transform;
        GameObject walls = new GameObject("Wall Parent");
        walls.transform.parent = Building.transform;
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GenerateFloor(x, y).transform.parent = flpors.transform;
                Debug.Log("Is Edge: " + IsEdge(x, y, CardinalDirection.UP) + " UP");
                if (IsEdge(x, y, CardinalDirection.UP))
                {
                    GenerateWalls(x, y, CardinalDirection.UP).transform.parent = walls.transform;
                }
                Debug.Log("Is Edge: " + IsEdge(x, y, CardinalDirection.RIGHT) + " RIGHT");
                if (IsEdge(x, y, CardinalDirection.RIGHT))
                {
                    GenerateWalls(x, y, CardinalDirection.RIGHT).transform.parent = walls.transform;
                }
                Debug.Log("Is Edge: " + IsEdge(x, y, CardinalDirection.DOWN) + " DOWN");
                if (IsEdge(x, y, CardinalDirection.DOWN))
                {
                    GenerateWalls(x, y, CardinalDirection.DOWN).transform.parent = walls.transform;
                }
                Debug.Log("Is Edge: " + IsEdge(x, y, CardinalDirection.LEFT) + " LEFT");
                if (IsEdge(x, y, CardinalDirection.LEFT))
                {
                   GenerateWalls(x, y, CardinalDirection.LEFT).transform.parent = walls.transform;
                }
            }        
        }
        Debug.Log("Generation Compleate");
        return Building;   
    }
    private bool IsEdge(int  x, int y,CardinalDirection dire)
    {
        return !HasFloorNeighbor(x, y, dire);
    }
    private GameObject GenerateWalls(int x, int y,CardinalDirection direction)
    {

        Vector3 floorPosition = new Vector3(x, 0f, y);
        Quaternion wallRotation = Quaternion.identity;
        Vector3 wallOffset = Vector3.zero;

        switch (direction)
        {
            case CardinalDirection.UP:
                wallOffset = new Vector3(0, 0, -0.5f);
                break;
            case CardinalDirection.DOWN:
                wallRotation = Quaternion.Euler(0f, 180f, 0f);
                wallOffset = new Vector3(0, 0, 0.5f);
                break;
            case CardinalDirection.LEFT:
                wallRotation = Quaternion.Euler(0f, -90f, 0f);
                wallOffset = new Vector3(-0.5f, 0, 0);
                break;
            case CardinalDirection.RIGHT:
                wallRotation = Quaternion.Euler(0f, 90f, 0f);
                wallOffset = new Vector3(0.5f, 0, 0);
                break;
            default:
                break;
        }

        GameObject obj = Instantiate(wallPrefab, floorPosition + wallOffset, wallRotation);
        GetCusotmGrid[x, y, (int)direction] = new Cell(IsEdge(x, y, direction),direction);
        obj.name = "Wall: " + direction.ToString() + " " + x + " : " + y;
        return obj;
    }

    private GameObject GenerateFloor(int x, int y)
    {
        Vector3 floorPosition = new Vector3(x, 0.0f, y);
        return Instantiate(floorPrefab, floorPosition, Quaternion.identity);
    }
    private bool HasFloorNeighbor(int x, int y, CardinalDirection cordinalDirection)
    {
        switch (cordinalDirection)
        {
            case CardinalDirection.UP:
                return (y > 0) ? GetCusotmGrid[x, y - 1,(int)cordinalDirection] != null : false ;
            case CardinalDirection.RIGHT:
                return (x < gridWidth - 1) ? GetCusotmGrid[x + 1, y, (int)cordinalDirection] != null : false; 
            case CardinalDirection.DOWN:
                return (y < gridHeight- 1) ? GetCusotmGrid[x, y + 1, (int)cordinalDirection] != null : false;
            case CardinalDirection.LEFT:
                return (x > 0) ? GetCusotmGrid[x - 1, y, (int)cordinalDirection] != null : false; 
            default:
                return false;
        }
    }

}
   




