namespace CardGames
{
    public interface ITeamable<TTeam>
    {
        TTeam Team { get; }
    }
}