using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Timeline;

public class ConfirmAction : InputReceiver
{
    VolumeCursorData controller;
    MovingSystem movingSystem;
    CursorMovementControl movementControl;
    MainReceiver mainReceiver;
    UniifiedStorage storage;
    public ConfirmAction(VolumeCursorData controller, MovingSystem movingSystem, CursorMovementControl movementControl, 
        MainReceiver mainReceiver, UniifiedStorage storage)
    {
        this.controller = controller;
        this.movementControl = movementControl;
        this.movingSystem = movingSystem;
        this.mainReceiver = mainReceiver;
        this.storage = storage;
    }
    public void startAction()
    { 
        //controller.extractor.marker = storage.getUnit().pos;
        float posY = movementControl.cursor.transform.position.y;
        movementControl.cursor.transform.position = new Vector3(storage.getUnit().transform.position.x, posY, storage.getUnit().transform.position.z);
        controller.zoneEffectSystem.fillZone(storage.walkingZone.getPositions());
    }
    public void receiveInput(ActionNames name)
    {
        if(name.Equals(ActionNames.Escape))
        {
            Unit unit = storage.getUnit();
            Dijsktra zone = storage.walkingZone;
            controller.zoneEffectSystem.eraseTiles(zone.getPositions());
            mainReceiver.changeInputReceiver(UINames.ChoseUnitAction);
            //controller.extractor.marker = storage.getUnit().pos;
            controller.extractor.marker = unit.pos;
            movingSystem.moveUnit(new PathData(unit, controller.extractor.marker));
            movementControl.PlaceOnUnit(unit);
        }
        if (name.Equals(ActionNames.Up))
        {
            moveCursors(new Vector2Int(0, 1));
        }
        if (name.Equals(ActionNames.Right))
        {
            moveCursors(new Vector2Int(1, 0));
        }
        if (name.Equals(ActionNames.Down))
        {
            moveCursors(new Vector2Int(0, -1));
        }
        if (name.Equals(ActionNames.Left))
        {
            moveCursors(new Vector2Int(-1, 0));
        }
        if (name.Equals(ActionNames.Confirm)) {
            Unit unit = storage.getUnit();
            Dijsktra zone = storage.walkingZone;
            movingSystem.moveUnit(new PathData(unit, controller.extractor.marker));
            controller.zoneEffectSystem.eraseTiles(new Zone(zone.getPositions(), new Vector2Int[0]));
            //storage.setSkillList(unit.GetGameClass().currentStance);
            mainReceiver.showFlatMenu(UINames.ChoseSkillMenu);
        }
    }
    public void moveCursors(Vector2Int direction)
    {
        Dijsktra zone = storage.walkingZone;
        if (zone.Contains(controller.extractor.marker + direction))
        {
            if (controller.extractor.changePosition(direction))
            {
                movementControl.moveCursor(direction);
            }
        }
    }
}
