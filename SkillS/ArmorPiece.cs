using UnityEngine;

public class ArmorPiece
{
    public SkillDirection direction;
    public int durability;
    public int weight;
    public string name;
    public ArmorPiece(SkillDirection direction, int durability, int weight, string name)
    {
        this.direction = direction;
        this.durability = durability;
        this.weight = weight;
        this.name = name;
    }
}
