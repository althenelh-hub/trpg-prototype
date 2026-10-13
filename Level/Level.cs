using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public Terrain[,] map;
    public int cellSize = 4;
    public Dictionary<Vector2Int, Unit> units = new Dictionary<Vector2Int, Unit>();
    public Dictionary<Vector2Int, MapObject> interactableObjects = new Dictionary<Vector2Int, MapObject>();
    public bool phase = true;
    public Level(int sizeX, int sizeY)
    {
        map = new Terrain[sizeX, sizeY];
        for(int i = 0;i < sizeX;i++)
        {
            for(int j = 0;j < sizeY; j++)
            {
                if (i == 2 && j == 2)
                {
                    map[i, j] = new Terrain(true, TerrainName.Wall);
                }
                else if (i == 2 && j == 1)
                {
                    map[i, j] = new Terrain(false, TerrainName.Forest);
                }
                else if (i == 2 && j == 0)
                {
                    map[i, j] = new Terrain(false, TerrainName.Forest);
                }
                else
                {
                    map[i, j] = new Terrain(false, TerrainName.Plain);
                }
            }
        }
    }
    public void addUnit(Unit unit)
    {
        Vector3 position = unit.transform.position/cellSize;
        Vector2Int pos = new Vector2Int(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.z));
        units.Add(pos, unit);
        unit.pos = pos;
    }
}
