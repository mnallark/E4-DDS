namespace Fire_Emblem_Model;

public class Unit
{
    public string Name { get; set; }
    public string Weapon { get; set; }
    public string Gender { get; set; }
    public string DeathQuote { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Atk { get; set; }
    public int Spd { get; set; }
    public int Def { get; set; }
    public int Res { get; set; }
    public int BaseAtk { get; set; }
    public int BaseSpd { get; set; }
    public int BaseDef { get; set; }
    public int BaseRes { get; set; }
    public Player Owner;
    public double WeaponTriangleBonusAmount;
    public Unit Opponent;
    public Unit LastOpponent;
    public bool StartsCombat;
    public bool HasAttackedBefore;
    public int PreCombatHpThatHasLoss;
    public bool DoesTheFollowUp;
    public bool IsFirstCombatAsInitiator;
    public bool IsFirstCombatAsDefender;
    public bool HasHpBonusApplied;
    public int HpAtTheBeginningOfCombat;
    public int Damage;
    public readonly UnitSkillsCollection SkillsCollection = new();
    public readonly EffectsCollection EffectsCollection = new();

    public Unit(string name, string weapon, string gender, int hp, int atk, int spd, int def, int res)
    {
        Name = name;
        Weapon = weapon;
        Gender = gender;
        HpAtTheBeginningOfCombat = HP = MaxHP = hp;
        Atk = BaseAtk = atk;
        Spd = BaseSpd = spd;
        Def = BaseDef = def;
        Res = BaseRes = res;
        SetDefaultFlags();
    }

    private void SetDefaultFlags()
    {
        StartsCombat = false;
        HasAttackedBefore = false;
        IsFirstCombatAsInitiator = true;
        IsFirstCombatAsDefender = true;
        DoesTheFollowUp = false;
        HasHpBonusApplied = false;
    }
    
    public void AddSkill(Skill skill)
    {
        SkillsCollection.Append(skill);
    }
    
    public void AddEffect(Effect effect)
    {
        EffectsCollection.Append(effect);
    }
    
    public void SetWeaponTriangleBonus(double bonus)
    {
        WeaponTriangleBonusAmount = bonus;
    }
    
    public void ItsStartingTheBattle()
    {
        StartsCombat = true;
    }
    
    public void FightAgainst(Unit actualOpponent)
    {
        Opponent = actualOpponent;
    }
    
    public void UpdateModifiedUnitStats(ModifiedStatsToApplyOnUnit modifiedStatsToApply)
    {
        Atk = modifiedStatsToApply.GetModifiedAmount(StatType.Atk);
        Spd = modifiedStatsToApply.GetModifiedAmount(StatType.Spd);
        Def = modifiedStatsToApply.GetModifiedAmount(StatType.Def);
        Res = modifiedStatsToApply.GetModifiedAmount(StatType.Res);
        HP = modifiedStatsToApply.GetModifiedAmount(StatType.HP);
    }
    
    public void ChangeDoesFollowUpState()
    {
        DoesTheFollowUp = true;
    }
    
    public void FirstAttackCommitted()
    {
        HasAttackedBefore = true;
    }
    
    public void ChangePreCombatHpThatHasLossState()
    {
        PreCombatHpThatHasLoss = MaxHP - HP;
    }
    
    public bool IsAlive() 
        => HP > 0;
    
    public void SetPostCombatSettings()
    {
        ResetStats();
        ChangeFirstCombatAttributes();
        EffectsCollection.Clear();
        LastOpponent = Opponent;
    }

    public void ResetStats()
    {
        Atk = BaseAtk;
        Spd = BaseSpd;
        Def = BaseDef;
        Res = BaseRes;
    }

    public void ResetTemporaryStates()
    {
        HasAttackedBefore = false;
        StartsCombat = false;
        DoesTheFollowUp = false;
        HpAtTheBeginningOfCombat = HP;
    }
    
    private void ChangeFirstCombatAttributes()
    {
        if (StartsCombat)
            IsFirstCombatAsInitiator = false;

        if (Opponent.StartsCombat)
            IsFirstCombatAsDefender = false;
    }
}
