namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using Fire_Emblem_View;
using System;

public class HpModificationsPostCombatController
{
    private readonly IFireEmblemView _view;
    private const int MinHpReductionParameter = 1;
    
    public HpModificationsPostCombatController(IFireEmblemView view)
    {
        _view = view;
    }
    
    public void CheckHpModificationsPostCombat(Unit attackerUnit, Unit defenderUnit)
    {
        if (attackerUnit.IsAlive())
            CheckHpModifications(attackerUnit);

        if (defenderUnit.IsAlive())
            CheckHpModifications(defenderUnit);
    }

    private void CheckHpModifications(Unit unit)
    {
        var unitEffectsSummary = SummarizeEffects(unit);
        var (totalHpRecovery, totalHpReduction) = CalculateHpModifications(unitEffectsSummary);

        ProcessHpModification(unit, totalHpRecovery, totalHpReduction);
    }

    private EffectsSummaryCollection SummarizeEffects(Unit unit)
    {
        var effectSummarizer = new EffectSummarizer(unit);
        return effectSummarizer.SummarizeEffects();
    }

    private (double totalHpRecovery, double totalHpReduction) CalculateHpModifications(EffectsSummaryCollection unitEffectsSummary)
    {
        double totalHpRecovery = 0;
        double totalHpReduction = 0;

        var hpRecoveryEffects = unitEffectsSummary.GetEffectsByType(EffectType.HpRecoveryPostCombat);
        var hpReductionEffects = unitEffectsSummary.GetEffectsByType(EffectType.HpReductionPostCombat);

        totalHpRecovery = hpRecoveryEffects.Sum(effect => effect.changeAmount);
        totalHpReduction = hpReductionEffects.Sum(effect => effect.changeAmount);

        return (totalHpRecovery, totalHpReduction);
    }

    private void ProcessHpModification(Unit unit, double totalHpRecovery, double totalHpReduction)
    {
        double netChange = totalHpRecovery + totalHpReduction;

        if (netChange > 0)
        {
            ApplyHpRecovery(unit, netChange);
            AnnounceHpRecoveryEffect(unit, netChange);
        }
        else if (netChange < 0)
        {
            ApplyHpReductionPostCombat(unit, -netChange);
            AnnounceHpReductionPostCombatEffect(unit, -netChange);
        }
    }

    private void ApplyHpRecovery(Unit unit, double recoveryAmount)
    {
        unit.HP = Math.Min(unit.HP + Convert.ToInt32(recoveryAmount), unit.MaxHP);
    }

    private void AnnounceHpRecoveryEffect(Unit unit, double changeAmount)
    {
        _view.GetHpRecoveryPostCombatDescription(unit.Name, changeAmount);
    }
    
    private void ApplyHpReductionPostCombat(Unit unit, double reductionAmount)
    {
        unit.HP = Math.Max(unit.HP - Convert.ToInt32(reductionAmount), MinHpReductionParameter);
    }

    private void AnnounceHpReductionPostCombatEffect(Unit unit, double changeAmount)
    {
        _view.GetHpReductionPostCombatDescription(unit.Name, changeAmount);
    }
}
