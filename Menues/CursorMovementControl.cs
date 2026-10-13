using Unity.VisualScripting;
using UnityEngine;

public class CursorMovementControl
{
    public float distance = 4f;
    public GameObject cursor;
    public Camera camera;
    public CursorMovementControl(GameObject cursor, Camera camera)
    {
        this.cursor = cursor;
        this.camera = camera;
    } 
    public int yAxis = 0, xAxis = 0, range = 100;
    public void moveCursor(Vector2Int direction)
    {
        cursor.transform.Translate(new Vector3(direction.x, 0, direction.y) * distance);
        camera.transform.Translate(new Vector3(direction.x, direction.y, 0) * distance);
    }
    public void SetPosition (Vector2Int position)
    {
        float camPosY = camera.transform.position.y;
        cursor.transform.position = new Vector3(position.x, 0, position.y) * distance;
        camera.transform.position = new Vector3(position.x * distance, camPosY, position.y * distance);
    }
    public void PlaceOnUnit(Unit unit)
    {
        Vector3 pos = new Vector3(unit.pos.x, 0, unit.pos.y) * distance + new Vector3(distance,0 ,distance)/2;
        cursor.transform.position = pos;
        pos.y += camera.transform.position.y;
        camera.transform.position = pos;
    }
    public void SetPosition(Vector3 position)
    {
        float camPosY = camera.transform.position.y;
        cursor.transform.position = position;
        camera.transform.position = new Vector3(position.x, camPosY, position.z);
    }
    
}
