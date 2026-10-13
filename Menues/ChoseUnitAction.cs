using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class ChoseUnitAction : InputReceiver
{
    MainReceiver receiver;
    VolumeCursorData controller;
    CursorMovementControl movementControl;
    UniifiedStorage storage;
    public ChoseUnitAction(MainReceiver receiver, VolumeCursorData controller, CursorMovementControl movementControl, UniifiedStorage storage)
    {
        this.receiver = receiver;
        this.controller = controller;
        this.movementControl = movementControl;
        this.storage = storage;
    }
    public void startAction()
    {
        
    }
    public void receiveInput(ActionNames name)
    {
        if(name.Equals(ActionNames.Up))
        {
            moveCursors(new Vector2Int(0, 1));
        }
        if(name.Equals(ActionNames.Right))
        {
            moveCursors(new Vector2Int(1, 0));
        }
        if(name.Equals(ActionNames.Down))
        {
            moveCursors(new Vector2Int(0, -1));
        }
        if(name.Equals(ActionNames.Left))
        {
            moveCursors(new Vector2Int(-1, 0));
        }
        
        if (name.Equals(ActionNames.Confirm))
        {
            Extractor extractor = controller.extractor;
            Unit unit = extractor.getUnit();
            if (unit == null)
            {
                
            }
            else
            {
                if (unit.CompareTag("Player") && unit.isActive)
                {
                    Dijsktra zone = new Dijsktra();
                    zone.createZone(extractor, unit.GetComponent<Stats>().movement.getCurrentValue());
                    storage.setUnit(unit);
                    storage.walkingZone = zone;
                    receiver.changeInputReceiver(UINames.ConfirmMovement);
                }
            }
        }
    }
    public void moveCursors(Vector2Int direction) 
    {
        
            if (controller.extractor.changePosition(direction))
            {
                movementControl.moveCursor(direction);
            }
    }
}
