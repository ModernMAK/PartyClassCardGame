namespace CardGames
{
    public static class Helpers
    {
        public static int CalculateFullDamage<TUnit>(this IAttack<TUnit> attack, TUnit attacker, TUnit defender) =>
            attack.BaseDamage + attack.GetAttackerDamageMod(attacker) + attack.GetDefenderDamageMod(defender);

        public static int CalculateFullDefense<TUnit>(this IDefense<TUnit> defense, TUnit defender) =>
            defense.BaseDefense + defense.GetDefenseMod(defender);
    }
}