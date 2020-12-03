namespace CardGames
{
    public interface ICardInstance : IReferencable<ICardReference>, ICard
    {
        new int Cost { get; set; }
    }

    public interface IUniversalCardInstance<TUnit> : ICardInstance
    {
        IAttack<TUnit> AttackAffect { get; }
        IDefense<TUnit> DefenseAffect { get; }
    }
}