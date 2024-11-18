namespace Fire_Emblem_Model;

public class ExtraChivalryEffect : Effect
{
    private const double _reductionMultiplier = 0.5;
    private readonly int _oneHundred = 100;

    public override EffectType GetEffectType()
    {
        return EffectType.PercentageDamageReduction;
    }

    public override double GetChangeAmount(Unit unit)
    {
        double opponentLeftHPPorcentage = CalculateOpponentLeftHPPorcentage(unit.Opponent);
        return CalculateDamageReduction(opponentLeftHPPorcentage);
    }

    private double CalculateOpponentLeftHPPorcentage(Unit opponent)
    {
        return opponent.HpAtTheBeginningOfCombat * _oneHundred / opponent.MaxHP;
    }

    private double CalculateDamageReduction(double opponentLeftHPPorcentage)
    {
        return Math.Floor(opponentLeftHPPorcentage * _reductionMultiplier);
    }
}