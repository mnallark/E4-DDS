namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using System;

public class UnitModifierByStatEffects
{
    private const int _minParameter = 0;
    private readonly Unit _baseUnit;
    private readonly EffectsSummaryCollection _unitEffectsSummary;
    private int _atk;
    private int _spd;
    private int _def;
    private int _res;
    private int _hp;
    private readonly int _damage;

    public UnitModifierByStatEffects(Unit baseUnit)
    {
        _baseUnit = baseUnit;
        _atk = baseUnit.Atk;
        _spd = baseUnit.Spd;
        _def = baseUnit.Def;
        _res = baseUnit.Res;
        _hp = baseUnit.HP;
        _damage = baseUnit.Damage;
        _unitEffectsSummary = SummarizeEffects(baseUnit);
    }

    private EffectsSummaryCollection SummarizeEffects(Unit unit)
    {
        EffectSummarizer effectSummarizer = new EffectSummarizer(unit);
        return effectSummarizer.SummarizeEffects();
    }

    public void ApplyStatEffectsByType(EffectType targetEffectType)
    {
        var effects = _unitEffectsSummary.GetEffectsByType(targetEffectType);
        foreach (var (effectType, statType, changeAmount) in effects)
        {
            ApplyStatEffect(effectType, statType, changeAmount);
        }
    }

    private void ApplyStatEffect(EffectType effectType, StatType statType, double changeAmount)
    {
        if (effectType == EffectType.HpPercentageRecovery)
        {
            ApplyStatChange(statType, ProcessHpRecovery(changeAmount));
        }
        else if (effectType == EffectType.HpReductionPostCombat || effectType == EffectType.HpRecoveryPostCombat)
        {
            ApplyStatChange(statType, changeAmount);
        }
        else
        {
            if (!CheckIsEffectNeutralized(effectType, statType))
            {
                ApplyStatChange(statType, changeAmount);
            }
        }
    }
    
    private double ProcessHpRecovery(double amount)
    {
        double changeAmount = Math.Floor(_damage * amount / 100);
        return _hp + changeAmount > _baseUnit.MaxHP ? _baseUnit.MaxHP - _hp : changeAmount;
    }
    
    private void ApplyStatChange(StatType statType, double amount)
    {
        int changeAmount = Convert.ToInt32(amount);

        switch (statType)
        {
            case StatType.Atk:
                _atk += changeAmount;
                break;
            case StatType.Spd:
                _spd += changeAmount;
                break;
            case StatType.Def:
                _def += changeAmount;
                break;
            case StatType.Res:
                _res += changeAmount;
                break;
            case StatType.HP:
                _hp = Math.Max(_hp + changeAmount, _minParameter);
                _baseUnit.HasHpBonusApplied = true;
                break;
        }
    }

    private bool CheckIsEffectNeutralized(EffectType effectType, StatType statType)
    {
        var neutralizationType = NeutralizationPair.GetNeutralizationEffect(effectType);
        return _baseUnit.EffectsCollection.ContainsEffectType(neutralizationType, statType);
    }

    public int GetModifiedAtk() => _atk;
    public int GetModifiedSpd() => _spd;
    public int GetModifiedDef() => _def;
    public int GetModifiedRes() => _res;
    public int GetModifiedHp() => _hp;
}
