namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using System;

public class UnitModifierByDamageEffects
{
    private readonly EffectsSummaryCollection _unitEffectsSummary;
    private readonly EffectsSummaryCollection _opponentEffectsSummary;
    private double _cumulativePercentageReduction = 1;
    private double _cumulativeAbsoluteReduction = 0;
    private int _damage;

    public UnitModifierByDamageEffects(Unit baseUnit)
    {
        _damage = baseUnit.Damage;
        _unitEffectsSummary = SummarizeEffects(baseUnit);
        _opponentEffectsSummary = SummarizeEffects(baseUnit.Opponent);
    }

    private EffectsSummaryCollection SummarizeEffects(Unit unit)
    {
        EffectSummarizer effectSummarizer = new EffectSummarizer(unit);
        return effectSummarizer.SummarizeEffects();
    }

    public void ApplyDamageEffectsByType(EffectType effectType)
    {
        if (effectType.IsDamageExtraEffect())
            ApplyDamageExtraEffects(effectType);
        
        else
            ApplyDamageEffectsFromOpponent(effectType);
    }

    private void ApplyDamageExtraEffects(EffectType targetEffectType)
    {
        var effects = _unitEffectsSummary.GetEffectsByType(targetEffectType);
        foreach (var (_, _, changeAmount) in effects)
        {
            ApplyDamageExtra(changeAmount);
        }
    }

    private void ApplyDamageExtra(double changeAmount)
    {
        _damage += Convert.ToInt32(changeAmount);
    }

    private void ApplyDamageEffectsFromOpponent(EffectType targetEffectType)
    {
        var effects = _opponentEffectsSummary.GetEffectsByType(targetEffectType);
        foreach (var (effectType, _, changeAmount) in effects)
        {
            if (effectType.IsPercentageDamageReductionEffect())
                AccumulatePercentageReduction(changeAmount);

            if (effectType.IsDamageAbsoluteReductionEffect())
                AccumulateAbsoluteReduction(changeAmount);
        }
    }

    private void AccumulatePercentageReduction(double changeAmount)
    {
        _cumulativePercentageReduction *= 1 - changeAmount / 100;
    }

    private void AccumulateAbsoluteReduction(double changeAmount)
    {
        _cumulativeAbsoluteReduction += changeAmount;
    }

    public void ApplyCumulativeReductions()
    {
        if (_cumulativePercentageReduction != 1)
        {
            ApplyPercentageDamageReduction(_cumulativePercentageReduction);
        }

        ApplyDamageReduction(_cumulativeAbsoluteReduction);
    }

    private void ApplyPercentageDamageReduction(double changeAmount)
    {
        double newDamage = Math.Round(_damage * changeAmount, 9);
        _damage = Convert.ToInt32(Math.Floor(newDamage));
    }

    private void ApplyDamageReduction(double changeAmount)
    {
        _damage = Math.Max(0, _damage - Convert.ToInt32(changeAmount));
    }

    public int GetModifiedDamage() => _damage;
}
