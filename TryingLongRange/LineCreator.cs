using System.Collections.Generic;
using UnityEngine;
public class LineCreator
{
    public Unit unitCheck(Vector2Int start, Vector2Int end, Extractor extractor)
    {
        int dx = end.x - start.x;
        int dy = end.y - start.y;
        Vector2Int direction = new Vector2Int(getIntSign(dx), getIntSign(dy));
        dy = Mathf.Abs(dy);
        dx = Mathf.Abs(dx);
        int p = 0;
        Unit unit = null;
        if (dx >= dy)
        {
            p = 2 * dy - dx;
            while (start.x != end.x)
            {

                start.x += direction.x;
                if (p >= 0)
                {
                    start.y += direction.y;
                    p += 2 * dy - 2 * dx;
                }
                else
                {
                    p += 2 * dy;
                }
                if (!extractor.onTheMap(start))
                {
                    break;
                }
                if (extractor.getTerrain(start).solid)
                {
                    break;
                }
                unit = extractor.getUnit(start);
                if (unit != null)
                {
                    break;
                }

            }

        }
        else
        {
            p = 2 * dx - dy;
            while (start.y != end.y)
            {

                start.y += direction.y;
                if (p >= 0)
                {
                    start.x += direction.x;
                    p += 2 * dx - 2 * dy;
                }
                else
                {
                    p += 2 * dx;
                }
                if (!extractor.onTheMap(start))
                {
                    break;
                }
                if (extractor.getTerrain(start).solid)
                {
                    break;
                }
                unit = extractor.getUnit(start);
                if (unit != null)
                {
                    break;
                }
            }
        }
        return unit;
    }
    public int getIntSign(int x)
    {
        if (x > 0)
        {
            return 1;
        }
        else if (x < 0)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
    public Vector2Int[] createLine(Vector2Int start, Vector2Int end)
    {
        int dx = end.x - start.x;
        int dy = end.y - start.y;
        Vector2Int direction = new Vector2Int(getIntSign(dx), getIntSign(dy));
        dy = Mathf.Abs(dy);
        dx = Mathf.Abs(dx);
        int p = 0;
        List<Vector2Int> coordinates = new List<Vector2Int>();
        Debug.Log("Initial" + start);
        if (dx >= dy)
        {
            p = 2 * dy - dx;
            while (start.x != end.x)
            {
                Debug.Log("StartX" + start);
                coordinates.Add(start);
                start.x += direction.x;
                if (p >= 0)
                {
                    start.y += direction.y;
                    p += 2 * dy - 2 * dx;
                }
                else
                {
                    p += 2 * dy;
                }

            }
            
        }
        else
        {
            p = 2 * dx - dy;
            while (start.y != end.y)
            {
                Debug.Log("StartY" + start);
                coordinates.Add(start);
                start.y += direction.y;
                if(p >= 0)
                {
                    start.x += direction.x;
                    p += 2 * dx - 2 * dy;
                }
                else
                {
                    p += 2 * dx;
                }
            }
        }
        coordinates.Add(start);
        return coordinates.ToArray();
    }
}
