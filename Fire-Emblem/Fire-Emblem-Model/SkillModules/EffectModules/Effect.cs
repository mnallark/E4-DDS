namespace Fire_Emblem_Model;

public abstract class Effect
{
    protected StatType TargetStat;
    protected double ChangeAmount;
    
    public abstract EffectType GetEffectType();
    
    public StatType GetStatType()
    {
        return TargetStat;
    }
    
    public virtual double GetChangeAmount(Unit unit)
    {
        return ChangeAmount;
    }
    
    public virtual void AddEffectToUnit(Unit unit)
    {
        unit.AddEffect(this);
    }
}
