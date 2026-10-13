using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ZoneEffectSystem : MonoBehaviour 
{
    public Tilemap map;
    public TileBase tile;
    Dictionary<GameObject, TileBase> displayType = new Dictionary<GameObject, TileBase>(); 
    public void FillZone (Vector2Int[] tiles, GameObject tileType)
    {
        foreach (Vector2Int tilePos in tiles)
        {
            map.SetTile(new Vector3Int(tilePos.x, tilePos.y), displayType[tileType]);
        }
    }
    public void f(Zone zone)
    {
        foreach(Vector2Int tilePos in zone.emptyPos)
        {
            map.SetTile(new Vector3Int(tilePos.x, tilePos.y), tile);
        }
        foreach (Vector2Int tilePos in zone.enemyPos)
        {
            map.SetTile(new Vector3Int(tilePos.x, tilePos.y), tile);
        }
    }
    public void fillZone(Unit[] units)
    {
        Vector2Int pos = new Vector2Int(0, 0);
        foreach (Unit unit in units)
        {
            pos = unit.pos;
            map.SetTile(new Vector3Int(pos.x, pos.y), tile);
        }
    }
    public void fillZone(Vector2Int[] zone)
    {
        foreach (Vector2Int tilePos in zone)
        {
            map.SetTile(new Vector3Int(tilePos.x, tilePos.y), tile);
        }
    }
    public void fillZone(MapObject[] mapObjects)
    {
        Vector2Int pos = new Vector2Int(0, 0);
        foreach (MapObject mapObject in mapObjects)
        {
            pos = mapObject.pos;
            map.SetTile(new Vector3Int(pos.x, pos.y), tile);
        }
    }
    public void eraseTiles(Zone zone)
    {
        foreach(Vector2Int tilePos in zone.emptyPos) {
            map.SetTile(new Vector3Int(tilePos.x, tilePos.y), null);
        }
        foreach (Vector2Int tilePos in zone.enemyPos) {
            map.SetTile(new Vector3Int(tilePos.x, tilePos.y), null);
        }
    }
    public void eraseTiles(Vector2Int[] zone)
    {
        foreach(Vector2Int vec in zone)
        {
            map.SetTile(new Vector3Int(vec.x, vec.y), null);
        }
    }
}
