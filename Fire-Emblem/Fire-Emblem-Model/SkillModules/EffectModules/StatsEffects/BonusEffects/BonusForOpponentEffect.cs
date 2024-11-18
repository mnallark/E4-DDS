namespace Fire_Emblem_Model;

public class BonusForOpponentEffect : Effect
{
    public BonusForOpponentEffect(StatType targetStat, int bonus)
    {
        TargetStat = targetStat;
        ChangeAmount = bonus;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.Bonus;
    }
    
    public override void AddEffectToUnit(Unit unit)
    {
        unit.Opponent.AddEffect(this);
    }
}