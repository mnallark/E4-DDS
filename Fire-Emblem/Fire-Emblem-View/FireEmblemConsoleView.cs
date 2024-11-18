namespace Fire_Emblem_View;
using Fire_Emblem_Model;

// Esta clase tiene métodos que están definidos pero no se utilizan en la interfaz gráfica, y se dejan 
// vacíos para mantener la compatibilidad con la interfaz y asegurar la estabilidad del programa.
public class FireEmblemConsoleView : IFireEmblemView
{
    private readonly AbstractView _view;

    public static FireEmblemConsoleView BuildConsoleView()
        => new FireEmblemConsoleView(new ConsoleView());
    
    public static FireEmblemConsoleView BuildTestingView(string pathTestScript)
        => new FireEmblemConsoleView(new TestingView(pathTestScript));

    public static FireEmblemConsoleView BuildManualTestingView(string pathTestScript)
        => new FireEmblemConsoleView(new ManualTestingView(pathTestScript));

    private FireEmblemConsoleView(AbstractView newView)
    {
        _view = newView;
    }

    public string ReadLine() 
        => _view.ReadLine();
    
    public void AnnounceThatTeamIsInvalid()
        => _view.WriteLine("Archivo de equipos no válido");
    
    public void SelectTeamFileMessage()
        => _view.WriteLine("Elige un archivo para cargar los equipos");
    
    public string SelectTeamFile()
        => string.Empty;
    
    public string UnitSelection(Player player)
        => _view.ReadLine();
    
    public void DisplayTeams(int index, string fileName)
        => _view.WriteLine($"{index}: {fileName}");
    
    public void StartRoundInfo(int roundNumber, Unit attackerUnit)
        => _view.WriteLine($"Round {roundNumber++}: {attackerUnit.Name} ({attackerUnit.Owner.Name}) comienza");

    public void SelectionOptionMessage(Player player)
        => _view.WriteLine($"{player.Name} selecciona una opción");

    public void UnitSelectionOptions(int unitNumberOnTeam, Player player)
        => _view.WriteLine($"{unitNumberOnTeam}: {player.Team[unitNumberOnTeam].Name}");

    public void AdvantageAnnouncement(Unit advantagedUnit, Unit disadvantagedUnit)
        => _view.WriteLine($"{advantagedUnit.Name} ({advantagedUnit.Weapon}) tiene ventaja con respecto a " +
                           $"{disadvantagedUnit.Name} ({disadvantagedUnit.Weapon})");

    public void NoAdvantageAnnouncement()
        => _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");

    public void ShowAttackInfo(Unit unitAttacking, Unit unitDefending)
        => _view.WriteLine($"{unitAttacking.Name} ataca a {unitDefending.Name} con {unitAttacking.Damage} de daño");

    public void NoOneDoesFollowUpMessage(Unit attackerUnit, Unit defenderUnit)
    {
        if (attackerUnit.DoesTheFollowUp)
            _view.WriteLine($"{defenderUnit.Name} no puede hacer un follow up");
        else if (defenderUnit.DoesTheFollowUp)
            _view.WriteLine($"{attackerUnit.Name} no puede hacer un follow up");
        else
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
    }
    
    public void GetEffectDescription(Unit unit, AnnouncementEffectInfo effectInfo, double changeAmount)
    {
        var effectType = effectInfo.GetEffectType();
        var statType = effectInfo.GetStatType();
        
        if (effectType == EffectType.NeutralizationBonus)
            GetNeutralizationBonusDescription (unit.Name, statType);
        
        if (effectType == EffectType.NeutralizationPenalty)
            GetNeutralizationPenaltyDescription(unit.Name, statType);

        if (effectType == EffectType.NegationFollowUpGuaranteed)
            GetNegationFollowUpGuaranteedDescription(unit.Name);
        
        if (effectType == EffectType.NegationFollowUpNeutralization)
            GetNegationFollowUpNeutralizationDescription(unit.Name);
        
        if (changeAmount != 0)
        {
            if (effectType.IsStatEffect())
                GetStandardDescription(unit, effectInfo, changeAmount);
        
            if (effectType.IsDamageExtraEffect())
                GetDamageExtraDescription(unit.Name, effectType, changeAmount);

            if (effectType.IsPercentageDamageReductionEffect())
                GetPercentageDamageReductionDescription(unit.Name, effectType, changeAmount);
        
            if (effectType.IsDamageAbsoluteReductionEffect())
                GetDamageReductionDescription(unit.Name, changeAmount);
        
            if (effectType == EffectType.HpPercentageRecovery)
                GetHpPercentageRecoveryDescription(unit.Name, changeAmount);
            
            if (effectType == EffectType.FollowUpGuaranteed)
                GetFollowUpGuaranteedDescription(unit.Name, changeAmount);

            if (effectType == EffectType.FollowUpNeutralization)
                GetFollowUpNeutralizationDescription(unit.Name, changeAmount);
        }
    }
        
    private void GetNeutralizationBonusDescription(string unitName, StatType statType)
        => _view.WriteLine($"Los bonus de {statType} de {unitName} fueron neutralizados");

    private void GetNeutralizationPenaltyDescription(string unitName, StatType statType)
        => _view.WriteLine($"Los penalty de {statType} de {unitName} fueron neutralizados");
    
    private void GetDamageExtraDescription(string unitName, EffectType effectType, double changeAmount)
    {
        string condition = effectType switch
        {
            EffectType.DamageExtra => " en cada ataque",
            EffectType.DamageExtraOnFirstAttack => " en su primer ataque",
            EffectType.DamageExtraOnFollowUp => " en su Follow-Up",
            _ => string.Empty
        };
        
        _view.WriteLine($"{unitName} realizará +{changeAmount} daño extra{condition}");
    }
    
    private void GetPercentageDamageReductionDescription(string unitName, EffectType effectType, double changeAmount)
    {
        string condition = effectType switch
        {
            EffectType.PercentageDamageReduction => " de los ataques",
            EffectType.PercentageDamageReductionOnFirstAttack => " del primer ataque",
            EffectType.PercentageDamageReductionOnFollowUp => " del Follow-Up",
            _ => string.Empty
        };

        _view.WriteLine($"{unitName} reducirá el daño{condition} del rival en un {Convert.ToInt32(Math.Round(changeAmount))}%");
    }
    
    private void GetDamageReductionDescription(string unitName, double changeAmount)
        => _view.WriteLine($"{unitName} recibirá -{changeAmount} daño en cada ataque");
    
    private void GetHpPercentageRecoveryDescription(string unitName, double changeAmount)
        => _view.WriteLine($"{unitName} recuperará HP igual al {changeAmount}% del daño realizado en cada ataque");
    
    private void GetFollowUpGuaranteedDescription(string unitName, double changeAmount)
        => _view.WriteLine($"{unitName} tiene {changeAmount} efecto(s) que garantiza(n) su follow up activo(s)");
    
    private void GetFollowUpNeutralizationDescription(string unitName, double changeAmount)
        => _view.WriteLine($"{unitName} tiene {changeAmount} efecto(s) que neutraliza(n) su follow up activo(s)");
    
    private void GetNegationFollowUpGuaranteedDescription(string unitName)
        => _view.WriteLine($"{unitName} es inmune a los efectos que garantizan su follow up");
    
    private void GetNegationFollowUpNeutralizationDescription(string unitName)
        => _view.WriteLine($"{unitName} es inmune a los efectos que neutralizan su follow up");
    
    public void GetHpReductionPreCombatDescription(Unit unit, double changeAmount)
        => _view.WriteLine($"{unit.Name} recibe {-changeAmount} de daño antes de iniciar el combate y queda con {unit.HP} HP");
    
    private void GetStandardDescription(Unit unit, AnnouncementEffectInfo effectInfo, double changeAmount)
    {
        var effectType = effectInfo.GetEffectType();
        var statType = effectInfo.GetStatType();

        string sign = changeAmount > 0 ? "+" : "";
        string condition = effectType switch
        {
            EffectType.Bonus => string.Empty,
            EffectType.BonusOnFirstAttack => " en su primer ataque",
            EffectType.BonusOnFollowUp => " en su Follow-Up",
            EffectType.Penalty => string.Empty,
            EffectType.PenaltyOnFirstAttack => " en su primer ataque",
            EffectType.PenaltyOnFollowUp => " en su Follow-Up",
            _ => string.Empty
        };

        _view.WriteLine($"{unit.Name} obtiene {statType}{sign}{Convert.ToInt32(changeAmount)}{condition}");
    }

    public void GetCounterattackDenialDescription(string unitName)
        => _view.WriteLine($"{unitName} no podrá contraatacar");
    
    public void GetCounterattackNegationDenialDescription(string unitName)
        => _view.WriteLine($"{unitName} neutraliza los efectos que previenen sus contraataques");
    
    public void GetHpRecoveryPostAttackDescription(string unitName, double recoveryAmount, int unitHp)
    {
        if (recoveryAmount > 0) 
            _view.WriteLine($"{unitName} recupera {recoveryAmount} HP luego de atacar y queda con {unitHp} HP.");
    }
    
    public void GetHpReductionPostCombatDescription(string unitName, double changeAmount)
    {
        if (changeAmount > 0) 
            _view.WriteLine($"{unitName} recibe {changeAmount} de daño despues del combate");
    }
    
    public void GetHpRecoveryPostCombatDescription(string unitName, double changeAmount)
    {
        if (changeAmount > 0) 
            _view.WriteLine($"{unitName} recupera {changeAmount} HP despues del combate");
    }

    public void ShowUnitsCombatResults(Unit attackerUnit)
        => _view.WriteLine($"{attackerUnit.Name} ({attackerUnit.HP}) : " +
                        $"{attackerUnit.Opponent.Name} ({attackerUnit.Opponent.HP})");
    
    public void ShowGameFinished(Player winnerPlayer)
        => _view.WriteLine($"{winnerPlayer.Name} ganó");
    
    public string[] GetScript()
        => _view.GetScript();
    
    void IFireEmblemView.ShowUpdateTeams(PlayersCollection players) { }
}