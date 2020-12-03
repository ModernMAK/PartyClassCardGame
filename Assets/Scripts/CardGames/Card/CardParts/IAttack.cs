namespace CardGames
{
    public interface IAttack<in TUnit>
    {
        int GetAttackerDamageMod(TUnit self);
        int GetDefenderDamageMod(TUnit defender);
        int BaseDamage { get; }
    }
}