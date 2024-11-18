namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using Fire_Emblem_View;

public class HpRecoveryController
{
    private readonly IFireEmblemView _view;
    private readonly Unit _unit;
        
    public HpRecoveryController(IFireEmblemView view, Unit unit)
    {
        _view = view;
        _unit = unit;
    }
        
    public void ProcessHpRecovery()
    {
        var unitEffectsSummary = SummarizeEffects();
        var hpRecoveryEffects = unitEffectsSummary.GetEffectsByType(EffectType.HpPercentageRecovery);

        foreach (var (_, _, changeAmount) in hpRecoveryEffects)
        {
            ApplyHpRecovery();
            AnnounceEffect(changeAmount);
        }
    }

    private EffectsSummaryCollection SummarizeEffects()
    {
        var effectSummarizer = new EffectSummarizer(_unit);
        return effectSummarizer.SummarizeEffects();
    }

    private void ApplyHpRecovery()
    {
        var modifiedUnit = GetModifiedUnitWithHpRecovery();
        _unit.HP = modifiedUnit.GetModifiedHp();
    }

    private UnitModifier GetModifiedUnitWithHpRecovery()
    {
        var effectsToApply = new EffectsToApplyCollection();
        effectsToApply.Append(EffectType.HpPercentageRecovery);
        var modifiedUnit = new UnitModifier(_unit);
        
        return modifiedUnit.GetUnitAffectedBy(effectsToApply);
    }

    private void AnnounceEffect(double changeAmount)
    {
        int recoveryAmount = CalculateRecoveryAmount(changeAmount);
        _view.GetHpRecoveryPostAttackDescription(_unit.Name, recoveryAmount, _unit.HP);
    }

    private int CalculateRecoveryAmount(double changeAmount)
    {
        return Convert.ToInt32(Math.Floor(_unit.Damage * changeAmount / 100));
    }
}