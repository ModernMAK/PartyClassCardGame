namespace CardGames
{
    public class SimpleDefense :  IDefense<IUnitInstance>
    {
        public int GetDefenseMod(IUnitInstance self) => 0;

        public int BaseDefense { get; set; }
    }
}