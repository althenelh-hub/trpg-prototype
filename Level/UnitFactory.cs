using System.Collections.Generic;
using UnityEngine;

public class UnitFactory
{
    public Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();
    public Dictionary<string, GameClass> gameClasses = new Dictionary<string, GameClass>();
    public UnitFactory()
    {
        createWeapons();
        createGameClasses();
    }
    public void createWeapons()
    {
        Dictionary<WeaponType, int> modifiers = new Dictionary<WeaponType, int>();
        modifiers.Add(WeaponType.LongRanged, 2);
        modifiers.Add(WeaponType.Blunt, 2);
        modifiers.Add(WeaponType.Slashing, 2);
        weapons.Add("Doubler", new Weapon(modifiers, 10, "Doubler"));
    }
    public void createGameClasses()
    {
        Skill[] skills = new Skill[3];
        SkillEffects[] effects = new SkillEffects[0];
        skills[0] = new MassSkill(1, effects, "Mass", WeaponType.Blunt, SkillDirection.Torso);
        skills[0].effects = new SkillEffects[] { new InflictDamage(100) };
        skills[1] = new PolyaxeSlashSkill(2, effects, "Circle", WeaponType.Slashing, SkillDirection.Torso);
        skills[1].effects = new SkillEffects[] { new InflictDamage(10) };
        skills[2] = new LongRangedSkill(3, effects, "Ranged", WeaponType.LongRanged, SkillDirection.Torso);
        skills[2].effects = new SkillEffects[] { new InflictDamage(10), new PushUnit() };
        GameClass gameClass = new GameClass();
        fillPerception(gameClass, 30, 70, 70, 70);
        gameClass.setStance(skills);
        gameClasses.Add("TestClass", gameClass);
    }
    private void fillPerception(GameClass gameClass, int torso, int arms, int head, int legs)
    {
        Dictionary<SkillDirection, int> perceptionRequirments = new Dictionary<SkillDirection, int>();
        perceptionRequirments.Add(SkillDirection.Torso, torso);
        perceptionRequirments.Add(SkillDirection.Arms, arms);
        perceptionRequirments.Add(SkillDirection.Head, head);
        perceptionRequirments.Add(SkillDirection.Legs, legs);
        gameClass.perceptionRequirment = perceptionRequirments;
    }
    public void fillUnit(Unit unit, string mainWeapon, string secondaryWeapon, string gameClass, int weight, 
        int stamina, int movement, int perception, int balance, int grip)
    {
        Equipment equipment = unit.GetComponent<Equipment>();
        if(weapons.ContainsKey(mainWeapon))
        {
            equipment.setMainWeapon(weapons[mainWeapon]);
        }
        if (weapons.ContainsKey(secondaryWeapon))
        {
            equipment.setSecondaryWeapon(weapons[secondaryWeapon]);
        }
        if (gameClasses.ContainsKey(gameClass))
        {
            unit.gameClass = gameClasses[gameClass];
        }
        unit.GetComponent<Stats>().SetCharacteristics(new Characteristic(weight), new Characteristic(stamina), 
            new Characteristic(movement), new Characteristic(perception), new Characteristic(balance), new Characteristic(grip));
    }
}
