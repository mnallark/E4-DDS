namespace Fire_Emblem_Model;

public class PenaltyEffect : Effect
{
    public PenaltyEffect(StatType targetStat, int penalty)
    {
        TargetStat = targetStat;
        ChangeAmount = -penalty;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.Penalty;
    }

    public override void AddEffectToUnit(Unit unit)
    {
        
        unit.Opponent.AddEffect(this);
    }
}