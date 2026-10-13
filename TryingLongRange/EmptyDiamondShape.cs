using System.Collections.Generic;
using UnityEngine;

public class EmptyDiamondShape
{
    public Vector2Int[] createDiamond(int radius, Vector2Int startPos)
    {
        int y = 0;
        int x = radius;
        List<Vector2Int> result = new List<Vector2Int>();
        result.Add(new Vector2Int(x, y) + startPos);
        result.Add(new Vector2Int(y, -x) + startPos);
        result.Add(new Vector2Int(-y, x) + startPos);
        result.Add(new Vector2Int(-x, -y) + startPos);
        while (y != radius-1)
        {
            x--;
            y++;
            result.Add(new Vector2Int(x, y) + startPos);
            result.Add(new Vector2Int(y, -x) + startPos);
            result.Add(new Vector2Int(-y, x) + startPos);
            result.Add(new Vector2Int(-x, -y) + startPos);

        }
        return result.ToArray();
    }
}
