using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class SkillUI : InputReceiver
{
    UniifiedStorage storage;
    Zone zone;
    VolumeCursorData volumeCursor;
    Dictionary<ShapeName, SkillShape> skillShapes =  new Dictionary<ShapeName, SkillShape>();
    public SkillShape currentShape;
    MainReceiver receiver;
    BattleSystem battleSystem;
    CursorMovementControl movementControl;
    Vector2Int fixPos;
    public SkillUI(VolumeCursorData volumeCursor, MainReceiver receiver, UniifiedStorage storage, BattleSystem battleSystem, CursorMovementControl movementControl)
    {
        this.receiver = receiver;
        this.volumeCursor = volumeCursor;
        this.battleSystem = battleSystem;
        this.storage = storage;
        this.movementControl = movementControl;
        skillShapes.Add(ShapeName.QuaterCircle, new HalfCircleSkill());
        skillShapes.Add(ShapeName.Rhombus, new RhombusShape());
    }
    public void startAction()
    {
        fixPos = volumeCursor.extractor.marker;
        Skill skill = storage.getSkill();
        currentShape = skillShapes[skill.shapeName];
        ZoneEffectSystem zoneEffectSystem = volumeCursor.zoneEffectSystem;
        zone = currentShape.showShape(skill.radius, volumeCursor.extractor);
        zoneEffectSystem.f(zone);
    }
    public void receiveInput(ActionNames action)
    {
        if(action.Equals(ActionNames.Up))
        {
            updateZone(new Vector2Int(0,1));
        }
        if (action.Equals(ActionNames.Right))
        {
            updateZone(new Vector2Int(1, 0));
        }
        if (action.Equals(ActionNames.Down))
        {
            updateZone(new Vector2Int(0,-1));
        }
        if (action.Equals(ActionNames.Left))
        {
            updateZone(new Vector2Int(-1, 0));
        }
        if (action.Equals(ActionNames.Escape))
        {
            
        }
        if(action.Equals(ActionNames.Escape))
        {
            ZoneEffectSystem zoneEffectSystem = volumeCursor.zoneEffectSystem;
            zoneEffectSystem.eraseTiles(zone);
            volumeCursor.extractor.marker = fixPos;
        }
        if(action.Equals(ActionNames.Confirm))
        {
            int i = 0;
            Unit[] units = new Unit[zone.enemyPos.Length];
            foreach(Vector2Int vec in zone.enemyPos)
            {
                Debug.Log(vec);
                units[i] = volumeCursor.extractor.getUnit(vec);
                i++;
            }
            Unit unit = storage.getUnit();
            Equipment equip = unit.GetComponent<Equipment>();
            battleSystem.performSkill(storage.getSkill(), units, equip.getMainWeapon(), unit, fixPos);  //get weapon later
            receiver.changeInputReceiver(UINames.ChoseUnitAction);
            volumeCursor.zoneEffectSystem.eraseTiles(zone);
        }
    }
    public void updateZone(Vector2Int direction)
    {
        Skill skill = storage.getSkill();
        ZoneEffectSystem zoneEffectSystem = volumeCursor.zoneEffectSystem;
        zoneEffectSystem.eraseTiles(zone);
        if (skill.shapeName.Equals(ShapeName.Rhombus))
        {
            movementControl.moveCursor(direction);
        }
        zone = currentShape.changeZone(skill.radius, volumeCursor.extractor, direction);  //change to rotate
        zoneEffectSystem.f(zone);
    }
}
