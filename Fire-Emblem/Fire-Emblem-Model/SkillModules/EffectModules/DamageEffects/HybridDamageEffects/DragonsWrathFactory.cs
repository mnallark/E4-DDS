namespace Fire_Emblem_Model;

public class DragonsWrathFactory
{
    private const int _percentageReductionOnFirstAttack = 25;
    private const double _extraDamageMultiplier = 0.25;

    public List<Effect> Create(Unit unit)
    {
        var effects = new List<Effect>();
        AddEffects(effects, unit);
        return effects;
    }

    private void AddEffects(List<Effect> effects, Unit unit)
    {
        effects.Add(new DamagePercentageReductionOnFirstAttackEffect(_percentageReductionOnFirstAttack));

        if (CheckConditionHolds(unit))
        {
            int changeAmount = CalculateExtraDamage(unit);
            effects.Add(new DamageExtraOnFirstAttackEffect(changeAmount));
        }
    }

    private bool CheckConditionHolds(Unit unit)
    {
        return unit.Atk >= unit.Opponent.Res;
    }

    private int CalculateExtraDamage(Unit unit)
    {
        return Convert.ToInt32(Math.Floor((unit.Atk - unit.Opponent.Res) * _extraDamageMultiplier));
    }
}