namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using Fire_Emblem_View;

public class HpModificationsPreCombatController
{
    private readonly IFireEmblemView _view;
    private const int _minHpReductionParameter = 1;

    public HpModificationsPreCombatController(IFireEmblemView view)
    {
        _view = view;
    }
        
    public void CheckHpModificationsPreCombat(Unit attackerUnit, Unit defenderUnit)
    {
        CheckHpModificationsPreCombatFrom(attackerUnit);
        CheckHpModificationsPreCombatFrom(defenderUnit);
    }

    private void CheckHpModificationsPreCombatFrom(Unit unit)
    {
        var unitEffectsSummary = SummarizeEffects(unit);

        var hpReductionEffects = unitEffectsSummary.GetEffectsByType(EffectType.HpReductionPreCombat);
        foreach (var (_, _, changeAmount) in hpReductionEffects)
        {
            ApplyAndAnnounceHpReduction(unit, changeAmount);
        }
    }

    private EffectsSummaryCollection SummarizeEffects(Unit unit)
    {
        var effectSummarizer = new EffectSummarizer(unit);
        return effectSummarizer.SummarizeEffects();
    }

    private void ApplyAndAnnounceHpReduction(Unit unit, double changeAmount)
    {
        ApplyHpReductionPreCombat(unit, changeAmount);
        AnnounceHpReductionEffect(unit, changeAmount);
    }

    private void ApplyHpReductionPreCombat(Unit unit, double changeAmount)
    {
        int newHpValue = unit.HP + Convert.ToInt32(changeAmount);
        unit.HP = newHpValue < _minHpReductionParameter ? _minHpReductionParameter : newHpValue;
    }
        
    private void AnnounceHpReductionEffect(Unit unit, double changeAmount)
    {
        _view.GetHpReductionPreCombatDescription(unit, changeAmount);
    }
}