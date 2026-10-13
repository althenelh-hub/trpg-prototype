using System.Collections.Generic;
using UnityEngine;

public class HalfCircleSkill : SkillShape
{
    public Vector2Int[] shapeToCoordinates(int size)
    {
        List<Vector2Int> coordinates = new List<Vector2Int>();
        int param = 1 - size;
        int x = size;
        int y = 0;
        coordinates.Add(new Vector2Int(x - 1, y));
        while (x > y)
        {
            y++;
            if (param <= 0)
            {
                param = param + 2 * y + 1;
            }
            else
            {
                x--;
                param = param + 2 * y - 2 * x + 1;
            }
            if (x < y)
            {
                break;
            }
            coordinates.Add(new Vector2Int(x - 1, y));
            coordinates.Add(new Vector2Int(x - 1, -y));
        }
        FastArcSinSort sort = new FastArcSinSort();
        return sort.sortArc(coordinates, size).ToArray();

    }
    public Zone createAttackRange(Extractor extractor, Vector2Int[] pos)
    {
        Terrain terrain;
        Unit unit;
        List<Vector2Int> empty = new List<Vector2Int>();
        List<Vector2Int> units = new List<Vector2Int>();
        Vector2Int interupted = pos[pos.Length - 1];
        Vector2Int marker = extractor.marker;
        Vector2Int current;
        foreach (Vector2Int tile in pos)
        {
            current = tile + marker;
            if (!extractor.onTheMap(current))
            {
                continue;
            }
            terrain = extractor.getTerrain(current);
            if (terrain == null)
            {
                interupted = tile; break;
            }
            if (terrain.solid)
            {
                interupted = tile; break;
            }
            unit = extractor.getUnit(current);
            if (unit != null)
            {
                units.Add(current);
                interupted = tile; break;

            }
            empty.Add(current);
        }
        if (!interupted.Equals(pos[pos.Length - 1]))
        {

            for (int i = pos.Length - 1; !pos[i].Equals(interupted); i--)
            {
                current = pos[i] + marker;
                if (!extractor.onTheMap(current))
                {
                    continue;
                }
                terrain = extractor.getTerrain(current);
                if (terrain == null)
                {
                    break;
                }
                if (terrain.solid)
                {
                    break;
                }
                unit = extractor.getUnit(current);
                if (unit != null)
                {
                    units.Add(current);
                    break;
                }
                empty.Add(current);
            }
        }
        return new Zone(empty.ToArray(), units.ToArray());
    }
    public override Zone showShape(int size, Extractor extractor)
    {
        Zone zone = createAttackRange(extractor, shapeToCoordinates(size));
        return createAttackRange(extractor, shapeToCoordinates(size));
    }
    public override Zone changeZone(int size, Extractor extractor, Vector2Int direction)
    {
        Vector2Int[] coordinates = shapeToCoordinates(size);
        coordinates = rotateZone(coordinates, direction);
        
        return createAttackRange(extractor, coordinates);
    }
    public Vector2Int[] rotateZone(Vector2Int[] coordinates, Vector2Int direction)
    {
        Vector2Int temp = new Vector2Int();
        for (int i = 0; i < coordinates.Length; i++) {
            temp = coordinates[i];
            coordinates[i].x = temp.x*direction.x - temp.y*direction.y;
            coordinates[i].y = temp.x*direction.y + temp.y*direction.x;
        }
        
        return coordinates;
    }

    
    
}
