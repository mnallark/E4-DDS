namespace Fire_Emblem_Model;

public class PlayersCollection
{
    private readonly List<Player> _players = new();

    public void CreatePlayers()
    {
        _players.Add(new Player("Player 1"));
        _players.Add(new Player("Player 2"));
    }
    
    public Player GetPlayer1()
        => _players[0];
    
    public Player GetPlayer2()
        => _players[1];

    public bool CheckPlayersUnitsAreAlive()
        => _players[0].Team.Count > 0 && _players[1].Team.Count > 0;

    public Player GetWinner()
    {
        if (Player1Loses())
            return _players[1];
        return _players[0];
    }
    
    private bool Player1Loses()
        => _players[0].Team.Count == 0;
}