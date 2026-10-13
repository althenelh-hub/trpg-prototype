using System.Collections.Generic;
using UnityEngine;
interface ChangableInteraction : CursoredButton
{
    public void switchMethod(bool mode);
}
class WeaponInteraction : ChangableInteraction
{
    Unit unit;
    Weapon weapon;
    bool equipMethdod = true;
    public WeaponInteraction(Unit unit, Weapon weapon)
    {
        this.unit = unit;
        this.weapon = weapon;
    }
    public void activate(MainReceiver receiver)
    {
        if (equipMethdod)
        {
            unit.GetComponent<Equipment>().setMainWeapon(weapon);
        }
        else
        {
            unit.GetComponent<Equipment>().setSecondaryWeapon(weapon);
        }
        receiver.hideUI(UINames.ConfirmInteraction);
        unit.isActive = false;
        receiver.changeInputReceiver(UINames.ChoseUnitAction);
    }
    public void switchMethod(bool mode)
    {
        equipMethdod = mode;
    }
}
class ArmorInteraction : ChangableInteraction
{
    ArmorPiece piece;
    Unit unit;
    public ArmorInteraction(ArmorPiece piece, Unit unit)
    {
        this.piece = piece;
        this.unit = unit;
    }
    public void activate(MainReceiver receiver)
    {
        unit.GetComponent<Equipment>().armor.AddArmor(piece);
        receiver.hideUI(UINames.ConfirmInteraction);
        unit.isActive = false;
        receiver.changeInputReceiver(UINames.ChoseUnitAction);
    }
    public void switchMethod(bool mode)
    {

    }
}
public class ConfirmInteractionUI : FlatMenu
{
    ChangableInteraction[] buttons;
    UniifiedStorage storage;
    MainReceiver receiver;
    public ConfirmInteractionUI(int step, int upperLimit, UniifiedStorage storage, MainReceiver receiver) : base(step, upperLimit)
    {
        this.storage = storage;
        this.receiver = receiver;
    }
    public override void startAction() {}
    public override void receiveInput(ActionNames name)
    {
        if(name.Equals(ActionNames.Confirm))
        {
            buttons[cursorPosition].activate(receiver);
        }
        if(name.Equals(ActionNames.Left))
        {
            buttons[cursorPosition].switchMethod(true);
        }
        if(name.Equals(ActionNames.Right))
        {
            buttons[cursorPosition].switchMethod(false);
        }
    }
    public void SetBodyMode(Body body)
    {
        List<ChangableInteraction> buttonsTemp  = new List<ChangableInteraction>();
        Weapon[] weapons = body.GetWeapons();
        Unit unit = storage.getUnit(); 
        ArmorPiece[] pieces = body.equipment.armor.GetArmor();
        string[] names = new string[weapons.Length + pieces.Length];
        int i = 0;
        foreach (Weapon weapon in weapons) {
            buttonsTemp.Add(new WeaponInteraction(unit, weapon));
            names[i] = weapon.name;
            i++;
        }
        foreach (ArmorPiece piece in pieces) {
            buttonsTemp.Add(new ArmorInteraction(piece, unit));
            names[i] = piece.name;
            i++;
        }
        buttons = buttonsTemp.ToArray();
        receiver.fillButtons(UINames.ConfirmInteraction, names, 50, 15, 220);
        upperLimit = buttons.Length-1;
    }
}

