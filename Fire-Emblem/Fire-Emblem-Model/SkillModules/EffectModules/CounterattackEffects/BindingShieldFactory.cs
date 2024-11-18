namespace Fire_Emblem_Model;

public class BindingShieldFactory
{
    public List<Effect> Create(Unit unit)
    {
        var effects = new List<Effect>();
        AddEffects(effects, unit);

        return effects;
    }

    private void AddEffects(List<Effect> effects, Unit unit)
    {
        if (CheckConditionHolds(unit))
            effects.Add(new CounterattackDenialEffect());
    }

    private bool CheckConditionHolds(Unit unit)
    {
        return unit.StartsCombat;
    }
}