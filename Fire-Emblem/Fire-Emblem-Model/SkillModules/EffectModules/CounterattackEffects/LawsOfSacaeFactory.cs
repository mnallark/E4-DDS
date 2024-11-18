namespace Fire_Emblem_Model;

public class LawsOfSacaeFactory
{
    public List<Effect> Create(Unit unit)
    {
        var effects = new List<Effect>();
        AddEffects(effects, unit);

        return effects;
    }

    private void AddEffects(List<Effect> effects, Unit unit)
    {
        if (CheckStartConditionHolds(unit))
        {
            if (CheckWeaponConditionHolds(unit) && CheckSpdConditionHolds(unit))
            {
                effects.Add(new CounterattackDenialEffect());
            }
        }
    }
    
    private bool CheckStartConditionHolds(Unit unit)
    {
        return unit.StartsCombat;
    }
    
    private bool CheckWeaponConditionHolds(Unit unit)
    {
        WeaponsCollection weaponsCondition = new();
        
        weaponsCondition.Append("Sword");
        weaponsCondition.Append("Lance");
        weaponsCondition.Append("Axe");

        return weaponsCondition.CheckWeaponCollectionContains(unit.Opponent.Weapon);
    }
    
    private bool CheckSpdConditionHolds(Unit unit)
    {
        return unit.Spd + 6 >= unit.Opponent.Spd + 5;
    }
}