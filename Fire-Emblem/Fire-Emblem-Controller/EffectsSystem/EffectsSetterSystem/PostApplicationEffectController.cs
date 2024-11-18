namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;

public class PostApplicationEffectsController
{
    private readonly Unit _unit;
    
    public PostApplicationEffectsController(Unit unit)
    {
        _unit = unit;
    }
    
    public void ProcessEffects()
    {
        foreach (var skill in _unit.SkillsCollection.GetAllSkills())
        {
            if (skill.Name == "Divine Recreation")
            {
                DivineRecreationController divineRecreationController = new(_unit);
                divineRecreationController.AddEffectToUnit();
            }
            
            if (skill.Name == "Bewitching Tome")
            {
                BewitchingTomeController bewitchingTomeController = new(_unit);
                bewitchingTomeController.AddEffectToUnit();
            }
            
            if (skill.Name == "Mastermind")
            {
                MastermindController mastermindController = new(_unit);
                mastermindController.AddEffectToUnit();
            }
        }
    }
}