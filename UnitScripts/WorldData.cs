using UnityEngine;

public class WorldData
{
    Vector2Int position;
    bool changed = false;
    public WorldData(Vector2Int position)
    {
        this.position = position;
    }
    public void changePosition(Vector2Int pos)
    {
        position = pos;
        changed = true;
    }
    public bool isChanged() { return changed; }
    public void confirmChange()
    {
        changed = false;
    }
    public Vector2Int getPosition() { return position; }

}
