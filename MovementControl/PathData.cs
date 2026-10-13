using UnityEngine;

public struct PathData
{
    public Unit unit;
    public Vector2Int endPos;
    public PathData(Unit _unit, Vector2Int _endPos)
    {
        unit = _unit;
        endPos = _endPos;
    }
}
