using System.Collections.Generic;
using UnityEngine;

public class TargetSelectUI : InputReceiver
{
    VolumeCursorData volumeCursorData;
    Unit[] targets;
    GameObject cursor;
    UniifiedStorage storage;
    BattleSystem battleSystem;
    CursorMovementControl movementControl;
    MainReceiver receiver;
    public TargetSelectUI(VolumeCursorData cursorData, GameObject cursor, UniifiedStorage storage, BattleSystem battleSystem, CursorMovementControl movementControl, MainReceiver receiver)
    {
        this.cursor = cursor;
        this.storage = storage;
        volumeCursorData = cursorData; 
        this.battleSystem = battleSystem;
        this.movementControl = movementControl;
        this.receiver = receiver;
    }
    int currentTarget = 0;
    public void startAction()
    {
        Skill skill = storage.getSkill();
        Extractor extractor = volumeCursorData.extractor;
        LineCreator lineCreator = new LineCreator();
        EmptyDiamondShape emptyDiamond = new EmptyDiamondShape();
        Unit unit = storage.getUnit();
        Vector2Int[] diamond = emptyDiamond.createDiamond(skill.radius, extractor.marker);
        ZoneEffectSystem effectSystem = volumeCursorData.zoneEffectSystem;
        Unit current = null;
        HashSet<Unit> units = new HashSet<Unit>();
        foreach(Vector2Int vec in diamond)
        {
            Vector2Int pos = unit.pos;
            current = lineCreator.unitCheck(extractor.marker, vec, extractor);
            if(current == unit)
            {
                continue;
            }
            if (current != null) {
                units.Add(current);
            }
        }
        targets = new Unit[units.Count];
        units.CopyTo(targets);
        effectSystem.fillZone(targets);
        Vector3 targetPosition = targets[currentTarget].transform.position;
        movementControl.SetPosition(new Vector3(targetPosition.x, 0, targetPosition.z));
    }
    public void receiveInput(ActionNames name)
    {
        if(name.Equals(ActionNames.Confirm))
        {
            Skill skill = storage.getSkill();
            Unit unit = storage.getUnit();
            Weapon weapon = unit.GetComponent<Equipment>().getMainWeapon();
            Vector2Int unitPos = volumeCursorData.extractor.marker;
            battleSystem.performSkill(skill, new Unit[] { targets[currentTarget] }, weapon, unit, unitPos);
            receiver.changeInputReceiver(UINames.ChoseUnitAction);
            movementControl.PlaceOnUnit(unit);
        }
        if (name.Equals(ActionNames.Down))
        {
            currentTarget = targets.Length - (targets.Length - currentTarget + 4) % (targets.Length - 1)-1;
            Vector3 targetPosition = targets[currentTarget].transform.position;
            movementControl.SetPosition(new Vector3(targetPosition.x, 0, targetPosition.z));
        }
        if (name.Equals(ActionNames.Up))
        {
            currentTarget = (currentTarget+4)%(targets.Length-1);
            Vector3 targetPosition = targets[currentTarget].transform.position;
            movementControl.SetPosition(new Vector3(targetPosition.x, 0, targetPosition.z));
        }
        if (name.Equals(ActionNames.Left))
        {
            currentTarget = ((targets.Length) - ((targets.Length) - (currentTarget+1)))%targets.Length;
            Vector3 targetPosition = targets[currentTarget].transform.position;
            movementControl.SetPosition(new Vector3(targetPosition.x, 0, targetPosition.z));
        }
        if (name.Equals(ActionNames.Right)) {
            currentTarget = (currentTarget + 1) % (targets.Length);
            Vector3 targetPosition = targets[currentTarget].transform.position;
            movementControl.SetPosition(new Vector3(targetPosition.x, 0, targetPosition.z));
        }
    }
}
