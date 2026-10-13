using UnityEngine;

public class BaseRangeScript : MonoBehaviour
{
    public GameObject cursor;
    Vector2Int cursorPos = new Vector2Int(0,0);
    public ZoneEffectSystem zoneEffect;
    LineCreator lineCreator = new LineCreator();
    Zone zone = new Zone(new EmptyDiamondShape().createDiamond(4, new Vector2Int(3,3)), new Vector2Int[0]);
    Vector2Int[] positions;
    Vector2Int startPos = new Vector2Int(0,0);
    public void Start()
    {
        //lineCreator.createLine(new Vector2Int(0, 0), new Vector2Int(5, 5));
        //lineCreator.createLine(new Vector2Int(1, 2), new Vector2Int(4, 7));
        zoneEffect.f(zone);
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveCursor(new Vector2Int(0, 1));
            zoneEffect.eraseTiles(zone);
            //Debug.Log("End pos" + cursorPos);
            positions = lineCreator.createLine(startPos, cursorPos);
            //Debug.Log("StartPos" + startPos);

            //foreach (Vector2Int vec in positions)
            //{
                //Debug.Log("Result " + vec);
            //}
            zone.emptyPos = positions;
            zoneEffect.f(zone);
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveCursor(new Vector2Int(1, 0));
            zoneEffect.eraseTiles(zone);
            zone.emptyPos = lineCreator.createLine(new Vector2Int(0, 0), cursorPos);
            zoneEffect.f(zone);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveCursor(new Vector2Int(0, -1));
            zoneEffect.eraseTiles(zone);
            zone.emptyPos = lineCreator.createLine(new Vector2Int(0, 0), cursorPos);
            zoneEffect.f(zone);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveCursor(new Vector2Int(-1, 0));
            zoneEffect.eraseTiles(zone);
            zone.emptyPos = lineCreator.createLine(new Vector2Int(0, 0), cursorPos);
            zoneEffect.f(zone);
        }

    }
    public void moveCursor(Vector2Int direction)
    {
        cursorPos += direction;
        cursor.transform.Translate(direction.x*4,0,direction.y*4);
    }
}
