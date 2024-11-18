namespace Fire_Emblem_Model;

public class UnitEffectsCollection
{
    private readonly Dictionary<Unit, List<EffectsCollection>> _unitEffects = new();
    
    public void AppendEffectList(Unit unit)
        => _unitEffects[unit] = new List<EffectsCollection>();

    public void AppendSkillEffects(Unit unit, List<Effect> skillEffects)
    {
        EffectsCollection unitSkillEffects = new();

        foreach (Effect effect in skillEffects)
        {
            unitSkillEffects.Append(effect);
        }
        
        _unitEffects[unit].Add(unitSkillEffects);
    }
    
    public EffectsCollection GetEffectsList(Unit unit, int index)
        => _unitEffects[unit][index];

    public int GetEffectsAmount(Unit unit)
        => _unitEffects[unit].Count;
}