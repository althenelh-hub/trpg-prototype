using UnityEngine;

public class MovingSystem
{
    public void moveUnit(PathData pathData)
    {
        float posY = pathData.unit.transform.position.y;
        pathData.unit.transform.position = new Vector3(pathData.endPos.x*4 + 2f, posY, pathData.endPos.y*4 + 2f);
    }
    public void moveUnit(Transform unit, Transform endPosition)
    {

    }
    public void moveUnit(Unit initiator, Unit target)
    {

    }
    
}
