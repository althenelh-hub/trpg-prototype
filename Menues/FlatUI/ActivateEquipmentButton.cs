using UnityEngine;

public class ActivateEquipmentMenu
{
    Weapon weapon;
    public void activate(MainReceiver receiver)
    {
        receiver.hideUI(UINames.ChoseSkillMenu);
        receiver.showFlatMenu(UINames.EquipmentMenu);
    }
}
