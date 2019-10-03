using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Controller : MonoBehaviour
{
    public GameObject Menu_Panel;
    public GameObject Roll_panel;
    public GameObject Str_stat;
    public GameObject Dex_stat;
    public GameObject Con_stat;
    public GameObject Int_stat;
    public GameObject Wis_stat;
    public GameObject Cha_stat;
    public GameObject Name_in;
    public GameObject Json_Out;
    public DnD_Abilities stats = new DnD_Abilities();

    int Str_mod;
    int Dex_mod;
    int Con_mod;
    int Int_mod;
    int Wis_mod;
    int Cha_mod;
    int Hit_die;


    private int Roll_stats()
    {
        int roll_1 = Random.Range(1, 7);
        int roll_2 = Random.Range(1, 7);
        int roll_3 = Random.Range(1, 7);
        int roll_4 = Random.Range(1, 7);
        int roll_5 = Random.Range(1, 7);
        int[] array = { roll_1, roll_2, roll_3, roll_4, roll_5 };
        System.Array.Sort(array);
        print(roll_1 + "," + roll_2 + "," + roll_3 + "," + roll_4 + "," + roll_5);


        int dice_1 = array[2];
        int dice_2 = array[3];
        int dice_3 = array[4];
        int stat = dice_1 + dice_2 + dice_3;
        print(dice_1 + "," + dice_2 + "," + dice_3 + ", total: " + stat);
        return stat;

    }

    private string ModTostring(int modifier)
    {
        string x = "";
        if (modifier < 0)
            x = modifier.ToString();
        if (modifier > 0)
            x = "+" + modifier;
        if (modifier == 0)
            x = "0";
        return x;
    }

    public void OnRoll()
    {
        int str = Roll_stats();
        Str_mod = (str - 10) / 2;
        stats.Ability_Strength = str;
        Scene_controller.Instance.Character.Ability_Strength = str;
        Text Str_Mod_Text = GameObject.Find("Str_mod Text").GetComponent<Text>();
        Text Str_text = Str_stat.GetComponent<Text>();
        Str_text.text = str.ToString();
        Str_Mod_Text.text = ModTostring(Str_mod);

        int dex = Roll_stats();
        Dex_mod = (dex - 10) / 2;
        stats.Armor_Class = Dex_mod + 10;
        Scene_controller.Instance.Character.Armor_Class = stats.Armor_Class;
        stats.Ability_Dexterity = dex;
        Scene_controller.Instance.Character.Ability_Dexterity = dex;
        Text Dex_Mod_Text = GameObject.Find("Dex_mod Text").GetComponent<Text>();
        Text Dex_text = Dex_stat.GetComponent<Text>();
        Dex_text.text = dex.ToString();
        Dex_Mod_Text.text = ModTostring(Dex_mod);

        int con = Roll_stats();
        Con_mod = (con - 10) / 2;
        stats.Ability_Constituion = con;
        Scene_controller.Instance.Character.Ability_Constituion = con;
        Text Con_Mod_Text = GameObject.Find("Con_mod Text").GetComponent<Text>();
        Text Con_text = Con_stat.GetComponent<Text>();
        Con_text.text = con.ToString();
        Con_Mod_Text.text = ModTostring(Con_mod);

        int intellegence = Roll_stats();
        Int_mod = (intellegence - 10) / 2;
        stats.Ability_Intellegence = intellegence;
        Scene_controller.Instance.Character.Ability_Intellegence = intellegence;
        Text Int_Mod_Text = GameObject.Find("Int_mod Text").GetComponent<Text>();
        Text Int_text = Int_stat.GetComponent<Text>();
        Int_text.text = intellegence.ToString();
        Int_Mod_Text.text = ModTostring(Int_mod);

        int wis = Roll_stats();
        Wis_mod = (wis - 10) / 2;
        stats.Ability_Wisdom = wis;
        Scene_controller.Instance.Character.Ability_Wisdom = wis;
        Text Wis_Mod_Text = GameObject.Find("Wis_mod Text").GetComponent<Text>();
        Text Wis_text = Wis_stat.GetComponent<Text>();
        Wis_text.text = wis.ToString();
        Wis_Mod_Text.text = ModTostring(Wis_mod);

        int cha = Roll_stats();
        Cha_mod = (cha - 10) / 2;
        stats.Ability_Charisma = cha;
        Scene_controller.Instance.Character.Ability_Charisma = cha;
        Text Cha_Mod_Text = GameObject.Find("Cha_mod Text").GetComponent<Text>();
        Text Cha_text = Cha_stat.GetComponent<Text>();
        Cha_text.text = cha.ToString();
        Cha_Mod_Text.text = ModTostring(Cha_mod);

        GameObject.Find("Roll_stats").SetActive(false);
    }

    public void Roll_Char()
    {
        if (Scene_controller.Instance.finished)
            Display_Character();
        Menu_Panel.SetActive(false);
        Roll_panel.SetActive(true);
    }

    public void Back()
    {
        Menu_Panel.SetActive(true);
        Roll_panel.SetActive(false);
    }

    public void Select_Race()
    {
        int index = GameObject.Find("Race Selection").GetComponent<Dropdown>().value;
        if (index == 1)
            stats.Race = "Dragonborn";
        if (index == 2)
            stats.Race = "Dwarf";
        if (index == 3)
            stats.Race = "Elf";
        if (index == 4)
            stats.Race = "Gnome";
        if (index == 5)
            stats.Race = "Half-Elf";
        if (index == 6)
            stats.Race = "Half-Orc";
        if (index == 7)
            stats.Race = "Halfling";
        if (index == 8)
            stats.Race = "Human";
        if (index == 9)
            stats.Race = "Tiefling";
        Scene_controller.Instance.Character.Race = stats.Race;
        Scene_controller.Instance.Race = index;
    }

    public void Select_Class()
    {
        int index = GameObject.Find("Class Selection").GetComponent<Dropdown>().value;
        if (index == 1)
        {
            stats.Class = "Barbarian";
            Hit_die = 12;
        }
        if (index == 2)
        {
            stats.Class = "Bard";
            Hit_die = 8;
        }
        if (index == 3)
        {
            stats.Class = "Cleric";
            Hit_die = 8;
        }
        if (index == 4)
        {
            stats.Class = "Druid";
            Hit_die = 8;
        }
        if (index == 5)
        {
            stats.Class = "Fighter";
            Hit_die = 10;
        }
        if (index == 6)
        {
            stats.Class = "Monk";
            Hit_die = 8;
        }
        if (index == 7)
        {
            stats.Class = "Paladin";
            Hit_die = 10;
        }
        if (index == 8)
        {
            stats.Class = "Ranger";
            Hit_die = 10;
        }
        if (index == 9)
        {
            stats.Class = "Rogue";
            Hit_die = 8;
        }
        if (index == 10)
        {
            stats.Class = "Sorcerer";
            Hit_die = 6;
        }
        if (index == 11)
        {
            stats.Class = "Warlock";
            Hit_die = 8;
        }
        if (index == 12)
        {
            stats.Class = "Wizard";
            Hit_die = 6;
        }
        Scene_controller.Instance.Character.Class = stats.Class;
        Scene_controller.Instance.Class = index;
    }

    public void Select_Alignment()
    {
        int index = GameObject.Find("Alignment Selection").GetComponent<Dropdown>().value;
        if (index == 1)
            stats.Alignment = "Lawful Good";
        if (index == 2)
            stats.Alignment = "Neutral Good";
        if (index == 3)
            stats.Alignment = "Chaotic Good";
        if (index == 4)
            stats.Alignment = "Lawful Neutral";
        if (index == 5)
            stats.Alignment = "Neutral";
        if (index == 6)
            stats.Alignment = "Chaotic Neutral";
        if (index == 7)
            stats.Alignment = "Lawful Evil";
        if (index == 8)
            stats.Alignment = "Neutral Evil";
        if (index == 9)
            stats.Alignment = "Chaotic Evil";
        Scene_controller.Instance.Alignment = index;
        Scene_controller.Instance.Character.Alignment = stats.Alignment;
    }
    public void Display_Character() 
    {
        //set overlay to previously rolled stats if there already is a complete character
        stats = Scene_controller.Instance.Character;

        int str = stats.Ability_Strength;
        Str_mod = (str - 10) / 2;
        Scene_controller.Instance.Character.Ability_Strength = str;
        Text Str_Mod_Text = GameObject.Find("Str_mod Text").GetComponent<Text>();
        Text Str_text = Str_stat.GetComponent<Text>();
        Str_text.text = str.ToString();
        Str_Mod_Text.text = ModTostring(Str_mod);

        int dex = stats.Ability_Dexterity;
        Dex_mod = (dex - 10) / 2;
        Text Dex_Mod_Text = GameObject.Find("Dex_mod Text").GetComponent<Text>();
        Text Dex_text = Dex_stat.GetComponent<Text>();
        Dex_text.text = dex.ToString();
        Dex_Mod_Text.text = ModTostring(Dex_mod);

        int con = stats.Ability_Constituion;
        Con_mod = (con - 10) / 2;
        Text Con_Mod_Text = GameObject.Find("Con_mod Text").GetComponent<Text>();
        Text Con_text = Con_stat.GetComponent<Text>();
        Con_text.text = con.ToString();
        Con_Mod_Text.text = ModTostring(Con_mod);

        int intellegence = stats.Ability_Intellegence;
        Int_mod = (intellegence - 10) / 2;
        Text Int_Mod_Text = GameObject.Find("Int_mod Text").GetComponent<Text>();
        Text Int_text = Int_stat.GetComponent<Text>();
        Int_text.text = intellegence.ToString();
        Int_Mod_Text.text = ModTostring(Int_mod);

 
        int wis = stats.Ability_Wisdom;
        Wis_mod = (wis - 10) / 2;
        Text Wis_Mod_Text = GameObject.Find("Wis_mod Text").GetComponent<Text>();
        Text Wis_text = Wis_stat.GetComponent<Text>();
        Wis_text.text = wis.ToString();
        Wis_Mod_Text.text = ModTostring(Wis_mod);

        int cha = stats.Ability_Charisma;
        Cha_mod = (cha - 10) / 2;
        Text Cha_Mod_Text = GameObject.Find("Cha_mod Text").GetComponent<Text>();
        Text Cha_text = Cha_stat.GetComponent<Text>();
        Cha_text.text = cha.ToString();
        Cha_Mod_Text.text = ModTostring(Cha_mod);

        GameObject.Find("Race Selection").GetComponent<Dropdown>().value = Scene_controller.Instance.Race;
        GameObject.Find("Class Selection").GetComponent<Dropdown>().value = Scene_controller.Instance.Class;
        GameObject.Find("Alignment Selection").GetComponent<Dropdown>().value = Scene_controller.Instance.Alignment;
        GameObject.Find("Character Name").GetComponent<InputField>().text = stats.Character_Name;
        Json_Out.GetComponent<InputField>().text = stats.SaveToString();

        GameObject.Find("Roll_stats").SetActive(false);

    }

    public void Make_Json()
    {
        if (Hit_die != 0)
        {
            Scene_controller.Instance.Character.Max_HP = Hit_die + Con_mod;
            Scene_controller.Instance.Character.Current_HP = Scene_controller.Instance.Character.Max_HP;
            stats.Max_HP = Hit_die + Con_mod;
            stats.Current_HP = stats.Max_HP;
        }
        Text character_name = Name_in.GetComponent<Text>();
        stats.Character_Name = character_name.text;
        Scene_controller.Instance.Character.Character_Name = character_name.text;
        Json_Out.GetComponent<InputField>().text = stats.SaveToString();
        Scene_controller.Instance.finished = true;
    }
    public void Load()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = (false);
#else
        Application.Quit();
#endif
    }
}
