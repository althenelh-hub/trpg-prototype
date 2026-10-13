using UnityEngine;

public class Extractor
{
    public Level level = new Level(5,5);
    public Vector2Int marker = new Vector2Int(0,0);
    public bool onTheMap(Vector2Int vec)
    {
        if (vec.x > level.map.GetLength(0) || vec.y > level.map.GetLength(1) || vec.x < 0 || vec.y < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public Terrain getTerrain()
    {
        return level.map[marker.x, marker.y]; 
    }
    public Terrain getTerrain(Vector2Int offset)
    {
        return level.map[offset.x, offset.y];
    }
    public Terrain getTerrainWithOffset(Vector2Int pos) //add check
    {
        Vector2Int vec = pos + marker; 
        if (!onTheMap(vec))
        {
            return null;
        }
        else
        {
            return level.map[vec.x, vec.y];
        }
        
    }
    public MapObject getMapObject()
    {
        if (level.interactableObjects.ContainsKey(marker))
        {
            return level.interactableObjects[marker];
        }
        else
        {
            return null;
        }
    }   
    public Unit getUnit()
    {
        if (level.units.ContainsKey(marker))
        {
            return level.units[marker];
        }
        else
        {
            Debug.Log("No such unit");
            return null;
        }
    }
    public Unit getUnit(Vector2Int offset)
    {
        if (level.units.ContainsKey(offset))
        {
            return level.units[offset];
        }
        else
        {
            Debug.Log("No such unit exists");
            return null;
        }
    }
    public Unit getUnitWithOffset(Vector2Int offset)
    {
        Vector2Int pos = offset + marker;
        if (level.units.ContainsKey(pos))
        {
            return level.units[pos];
        }
        else
        {
            Debug.Log("No such unit exists");
            return null;
        }

    }
    public bool changePosition(Vector2Int direction)
    {
        marker += direction;
        bool result = true;
        if (!onTheMap(marker))
        {
            marker -= direction;
            result = false;
        }
        return result;
    }
    public bool isPassable(Vector2Int pos)
    {
        Unit unit = getUnit(pos);
        Terrain terrian = getTerrain(pos);
        if(!terrian.solid && unit == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override string ToString()
    {
        return "Extractor";
    }
}
