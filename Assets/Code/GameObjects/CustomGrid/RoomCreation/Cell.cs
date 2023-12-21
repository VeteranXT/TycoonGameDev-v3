using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Cell
{
    [SerializeField] private bool isWall;
    [SerializeField] private CardinalDirection wallDirection;
    [SerializeField] private CardinalDirection doorDirection;
    [SerializeField] private Vector3 doorPosition;

    public bool IsWall {  get { return isWall; } }
    public CardinalDirection WallDirection { get { return wallDirection; } }
    public CardinalDirection DoorDirection { get { return doorDirection; } }
    public Vector3 DoorPosition { get { return doorPosition; } }
    public Cell(bool isWall, CardinalDirection wallDirection, CardinalDirection doorDirection, Vector3 doorPosition)
    {
        this.isWall = isWall;
        this.wallDirection = wallDirection;
        this.doorDirection = doorDirection;
        this.doorPosition = doorPosition;
    }

    public Cell(bool isWall, CardinalDirection wallDirection)
    {
        this.isWall = isWall;
        this.wallDirection = wallDirection;
    }
    public Cell()
    {

    }
    public Cell(Vector3 doorPosition, CardinalDirection doorDirection)
    {
        this.doorDirection = doorDirection;
        this.doorPosition = doorPosition;
    }
}


