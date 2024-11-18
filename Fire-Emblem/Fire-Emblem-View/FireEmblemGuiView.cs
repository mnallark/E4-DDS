namespace Fire_Emblem_View;
using Fire_Emblem_Model;
using Fire_Emblem_GUI;

// Esta clase tiene métodos que están definidos pero no se utilizan en la interfaz gráfica, y se dejan 
// vacíos para mantener la compatibilidad con la interfaz y asegurar la estabilidad del programa.
public class FireEmblemGuiView : IFireEmblemView
{
    private readonly FireEmblemWindow _window = new ();
    
    public void Start(Action startProgram) 
        => _window.Start(startProgram);

    public void AnnounceThatTeamIsInvalid()
        => _window.ShowInvalidTeamMessage();
    
    public string SelectTeamFile()
    {
        string team1 = FormatTeam(_window.GetTeam1());
        string team2 = FormatTeam(_window.GetTeam2());
        string data = FormatTeamData(team1, team2);
        string path = WriteTeamDataToFile(data);
        
        return path;
    }
    
    private string FormatTeam(string teamData)
        => teamData.Length == 0 ? "" : $"\n{teamData}";
    
    private string FormatTeamData(string team1, string team2)
        => $"Player 1 Team{team1}\nPlayer 2 Team{team2}";
    
    private string WriteTeamDataToFile(string data)
    {
        string path = Path.Combine(string.Empty, "gui_team.txt");
        File.WriteAllText(path, data); 
        return path;
    }
    
    public void ShowUpdateTeams(PlayersCollection players)
    {
        IUnit[] team1 = GetTeams(players.GetPlayer1());
        IUnit[] team2 = GetTeams(players.GetPlayer2());

        _window.UpdateTeams(team1, team2);
    }
    
    private IUnit[] GetTeams(Player player)
        => player.Team.Select(GetGuiUnit).ToArray();
    
    private GuiUnit GetGuiUnit(Unit unit)
    {
        string[] skills = unit.SkillsCollection.GetSkillsToArray();
        return new GuiUnit(unit.Name, unit.Weapon, unit.HP, unit.Atk, unit.Spd, unit.Def, unit.Res, skills);
    }

    public string UnitSelection(Player player)
        => player.Name == "Player 1" 
            ? _window.SelectUnitTeam1().ToString() 
            : _window.SelectUnitTeam2().ToString();
    
    public string ReadLine()
        => string.Empty;
    
    public void ShowAttackInfo(Unit unitAttacking, Unit unitDefending)
    {
        IUnit attacker = GetGuiUnit(unitAttacking);
        IUnit defender = GetGuiUnit(unitDefending);

        if (unitAttacking.Owner.Name == "Player 1")
            _window.ShowAttackFromTeam1(attacker, defender);
        
        else
            _window.ShowAttackFromTeam2(defender, attacker);
    }

    public void ShowGameFinished(Player winnerPlayer)
    {
        IUnit[] winningTeam = GetTeams(winnerPlayer);
        
        if (winnerPlayer.Name == "Player 1")
            _window.CongratulateTeam1(winningTeam);
        
        else
            _window.CongratulateTeam2(winningTeam);
    }

    void IFireEmblemView.SelectTeamFileMessage() { }
    void IFireEmblemView.DisplayTeams(int i, string fileName) { }
    void IFireEmblemView.StartRoundInfo(int roundNumber, Unit attackerUnit) { }
    void IFireEmblemView.SelectionOptionMessage(Player player) { }
    void IFireEmblemView.UnitSelectionOptions(int unitNumberOnTeam, Player player) { }
    void IFireEmblemView.AdvantageAnnouncement(Unit advantagedUnit, Unit disadvantagedUnit) { }
    void IFireEmblemView.NoAdvantageAnnouncement() { }
    void IFireEmblemView.NoOneDoesFollowUpMessage(Unit attackerUnit, Unit defenderUnit) { }
    void IFireEmblemView.GetEffectDescription(Unit unit, AnnouncementEffectInfo effectInfo, double changeAmount) { }
    void IFireEmblemView.GetHpReductionPreCombatDescription(Unit unit, double changeAmount) { }
    void IFireEmblemView.GetCounterattackDenialDescription(string unitName) { }
    void IFireEmblemView.GetCounterattackNegationDenialDescription(string unitName) { }
    void IFireEmblemView.GetHpRecoveryPostAttackDescription(string unitName, double recoveryAmount, int unitHp) { }
    void IFireEmblemView.GetHpReductionPostCombatDescription(string unitName, double changeAmount) { }
    void IFireEmblemView.GetHpRecoveryPostCombatDescription(string unitName, double changeAmount) { }
    void IFireEmblemView.ShowUnitsCombatResults(Unit attackerUnit) { }
}