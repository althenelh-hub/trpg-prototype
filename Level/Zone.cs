using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public struct Zone
{
    public Vector2Int[] emptyPos;
    public Vector2Int[] enemyPos;
    public Zone(Vector2Int[] _tiles, Vector2Int[] _units)
    {
        emptyPos = _tiles;
        enemyPos = _units;
    }
    
}
