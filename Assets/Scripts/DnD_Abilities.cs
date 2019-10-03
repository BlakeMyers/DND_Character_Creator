using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DnD_Abilities
{
    public string Character_Name;
    public int Ability_Strength;
    public int Ability_Dexterity;
    public int Ability_Constituion;
    public int Ability_Intellegence;
    public int Ability_Wisdom;
    public int Ability_Charisma;
    public string Race;
    public string Class;
    public string Alignment;
    public int Current_XP;
    public int Max_XP;
    public int Current_HP;
    public int Max_HP;
    public int Armor_Class;
    public int Speed_Walking;
    public int Speed_Running;
    public int Jump_Height;
    public List<string> Item_List = new List<string>();

    public DnD_Abilities()
    {
        Speed_Running = 60;
        Speed_Walking = 30;
        Jump_Height = 10;
    }

    public string SaveToString() 
    {
        return JsonUtility.ToJson(this);
    }

}
