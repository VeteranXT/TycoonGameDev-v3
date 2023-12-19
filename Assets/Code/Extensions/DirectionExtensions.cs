using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum CardinalDirection { UP, DOWN, LEFT, RIGHT }
public static class DirectionExtensions
{
    public static CardinalDirection GetOppositeDirection(this CardinalDirection direction)
    {
        switch (direction)
        {
            case CardinalDirection.UP: return CardinalDirection.DOWN;
            case CardinalDirection.DOWN: return CardinalDirection.UP;
            case CardinalDirection.LEFT: return CardinalDirection.RIGHT;
            case CardinalDirection.RIGHT: return CardinalDirection.LEFT;
            default: return CardinalDirection.UP;
        }
    }
}

