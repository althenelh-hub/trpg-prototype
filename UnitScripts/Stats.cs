using UnityEngine;

public class Stats : MonoBehaviour
{
    public Characteristic weight;
    public Characteristic stamina;
    public Characteristic movement;
    public Characteristic perception;
    public Characteristic balance;
    public Characteristic grip;
    public void SetCharacteristics(Characteristic weight, Characteristic stamina, Characteristic movement, 
        Characteristic perception, Characteristic balance, Characteristic grip)
    {
        this.weight = weight;
        this.stamina = stamina;
        this.movement = movement;
        this.perception = perception;
        this.balance = balance;
        this.grip = grip;
    }
}
