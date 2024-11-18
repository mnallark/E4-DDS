namespace Fire_Emblem_Model;

public class MoonTwinWingEffect : Effect
{
    private const double _minChangeAmount = 0;
    private const int _speedMultiplier = 4;
    private const double _maxReductionAmount = 40;

    public override EffectType GetEffectType()
    {
        return EffectType.PercentageDamageReduction;
    }

    public override double GetChangeAmount(Unit unit)
    {
        return unit.Spd > unit.Opponent.Spd
            ? CalculateDamageReduction(unit)
            : _minChangeAmount;
    }

    private double CalculateDamageReduction(Unit unit)
    {
        double speedDifference = Math.Abs(unit.Spd - unit.Opponent.Spd);
        return Math.Min(speedDifference * _speedMultiplier, _maxReductionAmount);
    }
}