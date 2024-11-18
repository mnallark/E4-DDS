namespace Fire_Emblem_Model;

public class BonusEffect : Effect
{
    public BonusEffect(StatType targetStat, int bonus)
    {
        TargetStat = targetStat;
        ChangeAmount = bonus;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.Bonus;
    }
}