namespace Fire_Emblem_Model;

public class HpPercentageRecoveryEffect : Effect
{
    private double _hpPercentage;
    
    public HpPercentageRecoveryEffect(int hpPercentage)
    {
        TargetStat = StatType.HP;
        _hpPercentage = hpPercentage;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.HpPercentageRecovery;
    }
    
    public override double GetChangeAmount(Unit unit)
    {
        return _hpPercentage;
    }
}