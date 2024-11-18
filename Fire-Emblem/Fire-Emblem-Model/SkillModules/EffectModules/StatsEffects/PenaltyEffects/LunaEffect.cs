namespace Fire_Emblem_Model;

public class LunaEffect : Effect
{
    private const int _minusChange = -1;
    private const int _effectDividisor = 2;
    public LunaEffect(StatType targetStat)
    {
        TargetStat = targetStat;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.PenaltyOnFirstAttack;
    }
    
    public override double GetChangeAmount(Unit unit)
    {
        switch (TargetStat)
        {
            case StatType.Def:
                ChangeAmount = unit.BaseDef / _effectDividisor * _minusChange;
                break;
            case StatType.Res:
                ChangeAmount = unit.BaseRes / _effectDividisor * _minusChange;
                break;
        }
        return ChangeAmount;
    }
    
    public override void AddEffectToUnit(Unit unit)
    {
        unit.Opponent.AddEffect(this);
    }
}