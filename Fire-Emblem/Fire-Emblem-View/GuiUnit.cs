namespace Fire_Emblem_Model;
using Fire_Emblem_GUI;

public class GuiUnit : IUnit
{
    public string Name { get; }
    public string Weapon { get; } 
    public int Hp { get; set; }
    public int Atk { get; }
    public int Spd { get; }
    public int Def { get; }
    public int Res { get; }
    public string[] Skills { get; }

    public GuiUnit(string name, string weapon, int hp, int atk, int spd, int def, int res, string[] skills)
    {
        Name = name;
        Weapon = weapon;
        Hp = hp;
        Atk = atk;
        Spd = spd;
        Def = def;
        Res = res;
        Skills = skills;
    }
}