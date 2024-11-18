namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using Fire_Emblem_View;

public class Game
{
    private readonly IFireEmblemView _view;
    private readonly PlayersCollection _players = new();
    private bool _successfulGameSetup = true;
    private readonly string _teamsFolder;
    private Unit _attackerUnit;
    private Unit _defenderUnit;
    
    public Game(IFireEmblemView view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        _players.CreatePlayers();
    }
    
    public Game(FireEmblemGuiView view)
    {
        _view = view;
        _players.CreatePlayers();
    }
    
    public void Play()
    {
        TeamsLoader teamsLoader = new TeamsLoader(_view, _teamsFolder, _players);
        teamsLoader.SetupTeams();

        CheckGameSetupValidation();
        
        if (_successfulGameSetup)
        {
            ShowUpdateTeamsOnView();
            ConductGameRounds();
        }
    }

    private void CheckGameSetupValidation()
    {
        try
        {
            TeamsValidator teamsValidator = new TeamsValidator();
            teamsValidator.CheckValidateTeams(_players);
        }
        catch (ValidationException)
        {
            _view.AnnounceThatTeamIsInvalid();
            _successfulGameSetup = false;
        }
    }

    private void ShowUpdateTeamsOnView()
    {
        _view.ShowUpdateTeams(_players);
    }

    private void ConductGameRounds()
    {
        Player attackerPlayer = _players.GetPlayer1();
        Player defenderPlayer = _players.GetPlayer2();
        int round = 1;
        
        while (CheckIsGameInProgress())
        {
            ExecuteRound(attackerPlayer, defenderPlayer, round++);
            
            if (CheckIsGameInProgress())
                (attackerPlayer, defenderPlayer) = (defenderPlayer, attackerPlayer);
            else
                FinishGame();
        }
    }
    
    private bool CheckIsGameInProgress()
    {
        return _players.CheckPlayersUnitsAreAlive();
    }
    
    private void ExecuteRound(Player attackerPlayer, Player defenderPlayer, int roundNumber)
    {
        _attackerUnit = ChooseUnitForPlayer(attackerPlayer);
        _defenderUnit = ChooseUnitForPlayer(defenderPlayer);
        
        _view.StartRoundInfo(roundNumber++, _attackerUnit);
        
        PlayRound();
    }
    
    private Unit ChooseUnitForPlayer(Player player)
    {
        _view.SelectionOptionMessage(player);
        ShowPlayerUnitsOptions(player);
        
        int unitInput = Convert.ToInt32(_view.UnitSelection(player));
        
        return player.ChooseStartingUnit(unitInput);
    }

    private void ShowPlayerUnitsOptions(Player player)
    {
        for (int unitNumberOnTeam = 0; unitNumberOnTeam < player.Team.Count; unitNumberOnTeam++)
        {
            _view.UnitSelectionOptions(unitNumberOnTeam, player);
        }
    }

    private void PlayRound()
    {
        SetPreCombatSetUp();
        PlayCombat();
        ShowUpdateTeamsOnView();
    }

    private void SetPreCombatSetUp()
    {
        PreCombatSetupManager preCombatSetupManager = new PreCombatSetupManager(_view, _attackerUnit, _defenderUnit);
        preCombatSetupManager.SetPreCombatSetUp();
    }

    private void PlayCombat()
    {
        CombatManager combatManager = new CombatManager(_view, _attackerUnit, _defenderUnit);
        combatManager.StartSingleCombat();
    }
    
    private void FinishGame()
    {
        Player winnerPlayer = _players.GetWinner();
        _view.ShowGameFinished(winnerPlayer);
    }
}
