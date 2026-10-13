using UnityEngine;

public class EquipmentCursoredButton
{
    ArmorPiece piece;
    UniifiedStorage storage;
    public void activate(MainReceiver receiver)
    {
        Unit unit = storage.getUnit();
        Equipment equimpment = unit.GetComponent<Equipment>();
        equimpment.armor.AddArmor(piece);
        unit.isActive = false;
        receiver.hideUI(UINames.ChoseSkillMenu);
        receiver.changeInputReceiver(UINames.ChoseUnitAction);
    }
}
