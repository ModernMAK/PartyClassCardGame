namespace CardGames
{
    public class SimpleAttack : IAttack<IUnitInstance>
    {
        public int GetAttackerDamageMod(IUnitInstance self) => 0;

        public int GetDefenderDamageMod(IUnitInstance defender) => 0;

        public int BaseDamage { get; set; }
    }
}