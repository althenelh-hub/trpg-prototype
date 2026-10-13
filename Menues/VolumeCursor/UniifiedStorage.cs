using System.Collections.Generic;
using UnityEngine;

public class UniifiedStorage
{
    Unit unit;
    Skill skill;
    Skill[] skillList;
    public Camera camera;
    List<MapObject> interactables = new List<MapObject>();
    public Dijsktra walkingZone = new Dijsktra();
    public void AddInteractable(MapObject interactable)
    {
        interactables.Add(interactable);
    }
    public List<MapObject> getInteractables ()
    {
        return interactables;
    }
    public Unit getUnit()
    {
        return unit;
    }
    public void setUnit(Unit unit)
    {
        this.unit = unit;
    }
    public void setSkillList(Skill[] skillList)
    {
        this.skillList = skillList;
    }
    public Skill[] getSkillList()
    {
        return skillList;
    }
    public Skill getSkill()
    {
        return skill;
    }
    public void setSkill(Skill skill) { this.skill = skill;} 
}
