namespace Fire_Emblem_Model;

public class TrueDragonWallFactory
{
    private const int _firstAttackMultiplier = 6;
    private const int _followUpMultiplier = 4;
    private const int _maxFirstAttackReduction = 60;
    private const int _maxFollowUpReduction = 40;

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
            int changeAmount = CalculatePercentageReduction(unit, _firstAttackMultiplier, _maxFirstAttackReduction);
            effects.Add(new DamagePercentageReductionOnFirstAttackEffect(changeAmount));

            changeAmount = CalculatePercentageReduction(unit, _followUpMultiplier, _maxFollowUpReduction);
            effects.Add(new DamagePercentageReductionOnFollowUpEffect(changeAmount));
        }
    }

    private bool CheckConditionHolds(Unit unit)
    {
        return unit.Res > unit.Opponent.Res;
    }

    private int CalculatePercentageReduction(Unit unit, int multiplier, int maxReduction)
    {
        int changeAmount = (unit.Res - unit.Opponent.Res) * multiplier;
        return Math.Min(changeAmount, maxReduction);
    }
}