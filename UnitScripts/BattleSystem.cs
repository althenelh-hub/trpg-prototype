using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BattleSystem
{
    public BattleSystem(Level level, DeadTransformer deadTransformer, LevelStatus levelStatus, MovingSystem movingSystem)
    {
        this.level = level;
        this.deadTransformer = deadTransformer;
        status = levelStatus;
        this.movingSystem = movingSystem;
    }
    Level level;
    DeadTransformer deadTransformer;
    Dictionary<TerrainName, int> terrainBonuses = new Dictionary<TerrainName, int>();
    LevelStatus status;
    MovingSystem movingSystem;
    public void performSkill(Skill skill, Unit[] targets, Weapon weapon, Unit performer, Vector2Int nextPos)
    {
        level.units.Remove(performer.pos);
        performer.pos = nextPos;
        level.units.Add(nextPos, performer);
        performer.isActive = false;
        status.decrease(performer);
        foreach (Unit target in targets) {
            Vector2Int pos = target.pos;
            if (target.gameClass.checkDirection(skill.direction) < performer.GetComponent<Stats>().perception.getCurrentValue() - target.GetComponent<Stats>().perception.getCurrentValue())
            {
                Debug.Log("Passed");
                skill.activate(performer, target, weapon);
            }
            skill.takeResources(performer);
            target.GetComponent<Stats>().perception.decrease(50);  //for faster testing
            Debug.Log(pos);
            Debug.Log(target.pos);
            foreach(Vector2Int position in level.units.Keys)
            {
                Debug.Log(position);
            }
            if (pos != target.pos)
            {
                level.units.Remove(pos);
                if (!level.units.ContainsKey(target.pos))
                {
                    level.units.Add(target.pos, target);
                    movingSystem.moveUnit(new PathData(target, target.pos));
                    Debug.Log(target.transform.position);
                    pos = target.pos;
                }
                else
                {
                    target.pos = pos;
                }
            }
            if (target.Dead)
            {
                level.units.Remove(pos);
                status.decreasAlive(target);
                Equipment equipment = performer.GetComponent<Equipment>();
                if(weapon == equipment.getMainWeapon())
                {
                    equipment.setMainWeapon(null);
                    Body body = deadTransformer.UnitToBody(target, weapon);
                    level.interactableObjects.Add(pos, body);
                }
                else if (weapon == equipment.getSecondaryWeapon()) 
                {
                    equipment.setSecondaryWeapon(null);
                    Body body = deadTransformer.UnitToBody(target, weapon);
                    level.interactableObjects.Add(pos, body);
                }
                else
                {
                    Body body = deadTransformer.UnitToBody(target, weapon);
                    level.interactableObjects.Add(pos, body);
                }
            }
            
        }
         
    } 
}
