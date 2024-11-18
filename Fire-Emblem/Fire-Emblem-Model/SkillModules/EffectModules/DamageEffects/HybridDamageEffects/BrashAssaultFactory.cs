namespace Fire_Emblem_Model;

public class BrashAssaultFactory
{
    private const double _percentageTarget = 0.3;
    
    public List<Effect> Create(Unit unit)
    {
        var effects = new List<Effect>();
        AddEffects(effects, unit);
        
        return effects;
    }
    
    private void AddEffects(List<Effect> effects, Unit unit)
    {
        int changeAmount = CalculateChangeAmount(unit);
        if (unit.StartsCombat)
            effects.Add(new DamageExtraOnFollowUpEffect(changeAmount));
        
        else
            effects.Add(new DamageExtraOnFirstAttackEffect(changeAmount));
    }
    
    private int CalculateChangeAmount(Unit unit)
    {
        int opponentsDamage = CalculateDamage(unit.Opponent);

        return Convert.ToInt32(Math.Floor(opponentsDamage * _percentageTarget));
    }
    
    private int CalculateDamage(Unit unit)
    {
        int attackerAttack = unit.Atk;
        int defenderDefense = GetDefenderDefense(unit.Opponent, unit.Weapon);
        
        return Math.Max(0, (int)(attackerAttack * unit.WeaponTriangleBonusAmount - defenderDefense));
    }
    
    private int GetDefenderDefense(Unit defender, string weaponType)
    {
        return weaponType == "Magic" ? defender.Res : defender.Def;
    }
}