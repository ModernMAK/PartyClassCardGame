namespace CardGames
{
    public interface ITargetter<TUnit>
    {
        bool CanTarget(TUnit target);
    }
}