using Unity.VisualScripting;
using UnityEngine;

public class DeadTransformer : MonoBehaviour
{
    public GameObject body;
    public Body UnitToBody(Unit unit, Weapon weapon)
    {
        GameObject instance = Instantiate(body);
        instance.transform.position = unit.transform.position;
        Body bod = instance.GetComponent<Body>();
        bod.pos = unit.pos;
        Equipment equip = instance.GetComponent<Equipment>();
        equip.armor = unit.GetComponent<Equipment>().armor;
        equip.setMainWeapon(unit.GetComponent<Equipment>().getMainWeapon());
        equip.setSecondaryWeapon(unit.GetComponent<Equipment>().getSecondaryWeapon());
        bod.SetEquipment(equip, weapon);
        Destroy(unit.gameObject);
        return bod;
    }
}
