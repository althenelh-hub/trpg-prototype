using System.Collections.Generic;
using UnityEngine;

public class Armor
{
    Dictionary<SkillDirection, ArmorPiece> armorPieces = new Dictionary<SkillDirection, ArmorPiece>();
    public void AddArmor(ArmorPiece piece)
    {
        if(armorPieces.ContainsKey(piece.direction))
        {
            armorPieces.Remove(piece.direction);
        }
        armorPieces.Add(piece.direction, piece);
    }
    public ArmorPiece[] GetArmor()
    {
        ArmorPiece[] pieces = new ArmorPiece[armorPieces.Count];
        int i = 0;
        foreach (ArmorPiece piece in armorPieces.Values)
        {
            pieces[i] = piece;
            i++;
        }
        return pieces;
    }
    public void receiveAttack(int damage, SkillDirection direction)
    {
        
        Debug.Log("Before Attack" + armorPieces[direction].durability);
        armorPieces[direction].durability -= damage;
        Debug.Log("After Attack" + armorPieces[direction].durability);
        if (armorPieces[direction].durability < 0) {
            removeArmor(direction);
        }
    }
    public bool checkArmor(SkillDirection direction)
    {
        return armorPieces.ContainsKey(direction);
    }
    public void removeArmor(SkillDirection direction)
    {
        armorPieces.Remove(direction);
    }
    
}
