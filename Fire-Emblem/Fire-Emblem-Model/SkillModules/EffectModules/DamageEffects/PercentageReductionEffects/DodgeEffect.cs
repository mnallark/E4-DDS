namespace Fire_Emblem_Model;

public class DodgeEffect : Effect
{
    private const int _speedMultiplier = 4;
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
        double speedDifference = Math.Abs(unit.Spd - unit.Opponent.Spd);
        return Math.Min(speedDifference * _speedMultiplier, _maxReductionAmount);
    }
}