namespace Fire_Emblem_Model;

public class PercentageDamageExtraEffectByOpponentStatEffect : Effect
{
    private readonly StatType _targetStat;
    private readonly int _targetPercentage;
    private readonly int _oneHundred = 100;

    public PercentageDamageExtraEffectByOpponentStatEffect(StatType targetStatType, int targetPercentage)
    {
        _targetStat = targetStatType;
        _targetPercentage = targetPercentage;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.DamageExtra;
    }
    
    public override double GetChangeAmount(Unit unit)
    {
        if (CheckConditionHolds(unit))
        {
            switch (_targetStat)
            {
                case StatType.Def:
                    ChangeAmount =  unit.Opponent.Def * _targetPercentage / _oneHundred;
                    break;
                
                default:
                    throw new InvalidStatType();
            }
        }

        return ChangeAmount;
    }

    private bool CheckConditionHolds(Unit unit)
    {
        return unit.Weapon != "Magic";
    }
}