using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class RhombusShape : SkillShape
{
    public override Zone changeZone(int movementRange, Extractor extractor, Vector2Int direction)
    {
        extractor.marker += direction;
        return showShape(movementRange, extractor);
    }
    public override Zone showShape(int movementRange, Extractor extractor)
    {
        int start = 0, end = 0;
        List<Vector2Int> emptyTiles = new List<Vector2Int>();
        List<Vector2Int> enemies = new List<Vector2Int>();
        Vector2Int marker = extractor.marker;
        Level level = extractor.level;
        Vector2Int currentPos;
        for (int i = -movementRange; i <= movementRange; i++)
        {
            for (int j = Mathf.Abs(i) - movementRange; j <= movementRange - Mathf.Abs(i); j++)
            {
                if (marker.x + j > level.map.GetLength(0) || marker.y + i > level.map.GetLength(1) || marker.x + j < 0 || marker.y + i < 0)
                {
                    continue;
                }
                currentPos = new Vector2Int((marker.x + j), (marker.y + i));
                ;
                if (level.units.ContainsKey(currentPos))
                {
                    enemies.Add(currentPos);
                }
                else
                {
                    emptyTiles.Add(currentPos);
                }

            }
            start--;
            end++;
        }
        return new Zone(emptyTiles.ToArray(), enemies.ToArray());
    }
}
