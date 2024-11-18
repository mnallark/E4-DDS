namespace Fire_Emblem_Model;

public class MastermindFactory
{
    private const int _hpReductionAmount = 1;
    private const int _bonusAmount = 9;
    private const int _hpThreshold = 2;

    public List<Effect> Create(Unit unit)
    {
        var effects = new List<Effect>();
        AddEffects(effects, unit);
        return effects;
    }

    private void AddEffects(List<Effect> effects, Unit unit)
    {
        if (CheckHpConditionHolds(unit))
            effects.Add(new HpReductionPreCombatEffect(_hpReductionAmount));

        if (CheckUnitStartsCombat(unit))
        {
            AddBonusEffects(effects);
        }
    }

    private bool CheckHpConditionHolds(Unit unit)
    {
        return unit.HP >= _hpThreshold;
    }
        
    private bool CheckUnitStartsCombat(Unit unit)
    {
        return unit.StartsCombat;
    }

    private void AddBonusEffects(List<Effect> effects)
    {
        effects.Add(new BonusEffect(StatType.Atk, _bonusAmount));
        effects.Add(new BonusEffect(StatType.Spd, _bonusAmount));
    }
}