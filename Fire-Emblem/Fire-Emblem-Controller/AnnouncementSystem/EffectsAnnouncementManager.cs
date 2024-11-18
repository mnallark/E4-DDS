namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using Fire_Emblem_View;

public class EffectsAnnouncementManager
{
    private readonly IFireEmblemView _view;
    private EffectsSummaryCollection _effectsSummary;
    
    public EffectsAnnouncementManager(IFireEmblemView view)
    {
        _view = view;
        _effectsSummary = new EffectsSummaryCollection();
    }
    
    public void AnnounceEffects(Unit attackerUnit, Unit defenderUnit)
    {
        AnnounceEffectsFrom(attackerUnit);
        AnnounceEffectsFrom(defenderUnit);
    }

    private void AnnounceEffectsFrom(Unit unit)
    {
        SummarizeEffectsFrom(unit);
        AnnounceAllEffects(unit);
    }
    
    private void SummarizeEffectsFrom(Unit unit)
    {
        EffectSummarizer effectSummarizer = new(unit);
        _effectsSummary = effectSummarizer.SummarizeEffects();
    }
    
    private void AnnounceAllEffects(Unit unit)
    {
        foreach (var effectType in _effectsSummary.GetEffectTypes())
        {
            ProcessEffectChangesToAnnounce(unit, effectType);
        }
    }

    private void ProcessEffectChangesToAnnounce(Unit unit, EffectType effectType)
    {
        foreach (var statType in _effectsSummary.GetStatTypes(effectType))
        {
            AnnounceEffect(unit, effectType, statType);
        }
    }

    private void AnnounceEffect(Unit unit, EffectType effectType, StatType statType)
    {
        var changeAmount = _effectsSummary.GetEffectStatChangeAmount(effectType, statType);

        AnnouncementEffectInfo effectInfo = new(effectType, statType);
        
        if (effectType.IsCounterattackEffect())
            AnnounceCounterattackEffect(unit);

        if (!effectType.IsEffectWithoutPreAnnouncementEstablished())
            _view.GetEffectDescription(unit, effectInfo, changeAmount);
    }

    private void AnnounceCounterattackEffect(Unit unit)
    {
        if (CheckShouldAnnounceCounterattackEffect(unit, EffectType.CounterattackDenial))
            _view.GetCounterattackDenialDescription(unit.Name);

        else
        {
            if (CheckShouldAnnounceCounterattackEffect(unit, EffectType.CounterattackNegationDenial))
                _view.GetCounterattackNegationDenialDescription(unit.Name);
        }
    }
    
    private bool CheckShouldAnnounceCounterattackEffect(Unit unit, EffectType effectType)
    {
        return EffectTypeCounter.CountEffectsByType(unit, effectType) > 0;
    }
}