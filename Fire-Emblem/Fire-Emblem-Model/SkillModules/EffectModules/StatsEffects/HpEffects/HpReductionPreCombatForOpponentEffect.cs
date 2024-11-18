namespace Fire_Emblem_Model;

public class HpReductionPreCombatForOpponentEffect : Effect
{
    public HpReductionPreCombatForOpponentEffect(int changeAmount)
    {
        TargetStat = StatType.HP;
        ChangeAmount = -changeAmount;
    }

    public override EffectType GetEffectType()
    {
        return EffectType.HpReductionPreCombat;
    }
    
    public override void AddEffectToUnit(Unit unit)
    {
        unit.Opponent.AddEffect(this);
    }
}