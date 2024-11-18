namespace Fire_Emblem_Model;

public class DragonWallEffect : Effect
{
    private const int _resistanceMultiplier = 4;
    private const double _maxReductionAmount = 40;

    public override EffectType GetEffectType()
    {
        return EffectType.PercentageDamageReduction;
    }

    public override double GetChangeAmount(Unit unit)
    {
        return CalculateDamageReduction(unit);
    }

    private double CalculateDamageReduction(Unit unit)
    {
        double resistanceDifference = Math.Abs(unit.Res - unit.Opponent.Res);
        return Math.Min(resistanceDifference * _resistanceMultiplier, _maxReductionAmount);
    }
}