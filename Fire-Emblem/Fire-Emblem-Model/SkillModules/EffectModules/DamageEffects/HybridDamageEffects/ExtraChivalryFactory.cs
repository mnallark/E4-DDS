namespace Fire_Emblem_Model;

public class ExtraChivalryFactory
{
    private const int _penaltyAmount = 5;
    private const double _hpThreshold = 0.5;

    public List<Effect> Create(Unit unit)
    {
        var effects = new List<Effect>();
        AddEffects(effects, unit);
        return effects;
    }

    private void AddEffects(List<Effect> effects, Unit unit)
    {
        if (CheckConditionHolds(unit))
        {
            AddPenaltyEffects(effects);
        }
            
        effects.Add(new ExtraChivalryEffect());
    }

    private bool CheckConditionHolds(Unit unit)
    {
        return unit.Opponent.HP >= unit.Opponent.MaxHP * _hpThreshold;
    }

    private void AddPenaltyEffects(List<Effect> effects)
    {
        effects.Add(new PenaltyEffect(StatType.Atk, _penaltyAmount));
        effects.Add(new PenaltyEffect(StatType.Spd, _penaltyAmount));
        effects.Add(new PenaltyEffect(StatType.Def, _penaltyAmount));
    }
}