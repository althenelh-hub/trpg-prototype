using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

class InteractionSkill : Skill
{
    public InteractionSkill(int _radius, SkillEffects[] _effects, string name) : base(_radius, _effects, name)
    {
        shapeName = ShapeName.Interaction;
        weaponType = WeaponType.Util;
    }
}
public class ChoseSkillMenu : FlatMenu
{
    MainReceiver receiver;
    UniifiedStorage storage;
    Weapon weapon;
    Skill[] skillList;
    public ChoseSkillMenu(float step, int upperLimit, MainReceiver _receiver, UniifiedStorage storage) : base(step, upperLimit)
    {
        receiver = _receiver;
        this.storage = storage;
    }
    public override void startAction()
    {
        Unit unit = storage.getUnit(); 
        Skill[] gameClassList = unit.gameClass.currentStance;
        skillList = new Skill[gameClassList.Length+1];
        int j = 0;
        foreach (Skill skill in gameClassList) {
            skillList[j] = skill;
            j++;
        }
        
        skillList[j] = new InteractionSkill(1, new SkillEffects[0], "interaction");
        upperLimit = skillList.Length;
        string[] texts = new string[upperLimit];
        for(int i = 0; i < upperLimit;i++)
        {
            texts[i] = skillList[i].name;
        }
        upperLimit--;
        receiver.fillButtons(UINames.ChoseSkillMenu, texts, 50, 15, 200);
        Equipment equip = unit.GetComponent<Equipment>();
        if (equip.getMainWeapon() != null)
        {
            weapon = equip.getMainWeapon();
        }
        else
        {
            weapon = equip.getSecondaryWeapon();
        }
    }
    public override void receiveInput(ActionNames action)
    {
        Equipment equip = storage.getUnit().GetComponent<Equipment>();
        if(action.Equals(ActionNames.Escape))
        {
            receiver.hideUI(UINames.ChoseSkillMenu);
            receiver.changeInputReceiver(UINames.ConfirmMovement);
        }
        if(action.Equals(ActionNames.Left))
        {
            weapon = equip.getMainWeapon();
        }
        if(action.Equals(ActionNames.Right))
        {
            weapon = equip.getSecondaryWeapon();
        }
        if(action.Equals(ActionNames.Confirm))
        {
            WeaponType[] types = weapon.getTypes();
            bool marker = false;
            foreach (WeaponType weaponType in types) {
                if (skillList[cursorPosition].weaponType.Equals(weaponType))
                {
                    marker = true;
                }
            }
            if (!marker && !skillList[cursorPosition].weaponType.Equals(WeaponType.Util)) {
                return;
            }
            storage.setSkill(skillList[cursorPosition]);
            receiver.changeInputReceiver(UINames.SkillControl);
            receiver.hideUI(UINames.ChoseSkillMenu);
        }
    }
    public override string ToString()
    {
        return "ChoseSkillMenu";
    }
}
