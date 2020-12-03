namespace CardGames
{
    public interface IDefense<in TUnit>
    {
        int GetDefenseMod(TUnit self);
        int BaseDefense { get; }
    }
}