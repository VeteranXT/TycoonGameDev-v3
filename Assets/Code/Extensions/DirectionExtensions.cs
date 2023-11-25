using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum CordinalDirection { UP, DOWN, LEFT, RIGHT }
public static class DirectionExtensions
{
    public static CordinalDirection GetOppositeDirection(this CordinalDirection direction)
    {
        switch (direction)
        {
            case CordinalDirection.UP: return CordinalDirection.DOWN;
            case CordinalDirection.DOWN: return CordinalDirection.UP;
            case CordinalDirection.LEFT: return CordinalDirection.RIGHT;
            case CordinalDirection.RIGHT: return CordinalDirection.LEFT;
            default: return CordinalDirection.UP;
        }
    }
}

