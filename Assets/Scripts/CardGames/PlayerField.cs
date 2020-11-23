namespace CardGames
{
    public class PlayerField<TO>
    {
        private readonly Deck<TO> _drawPile;
        private readonly Deck<TO> _discardPile;
        private readonly Deck<TO> _removePile;
        private readonly Hand<TO> _hand;

        public PlayerField() : this(new Deck<TO>(), new Hand<TO>(), new Deck<TO>(), new Deck<TO>())
        {
        }
        public PlayerField(Deck<TO> drawPile) : this(drawPile, new Hand<TO>(), new Deck<TO>(), new Deck<TO>())
        {
            //Assume discard pile and remove pile are empty decks
            //Assume hand is empty
        }

        public PlayerField(Deck<TO> drawPile, Hand<TO> hand, Deck<TO> discardPile, Deck<TO> removePile)
        {
            _drawPile = drawPile;
            _hand = hand;
            _discardPile = discardPile;
            _removePile = removePile;
        }

        public void Clear()
        {
            Hand.Clear();
            DrawPile.Clear();
            DiscardPile.Clear();
            RemovePile.Clear();
        }

        public void Reset<TI>(Deck<TI> deck) where TI : IInstancable<TO>
        {
            deck.CreateInstance(_drawPile);
            _drawPile.UnityShuffle();
        }

        public Hand<TO> Hand => _hand;
        public Deck<TO> DrawPile => _drawPile;
        public Deck<TO> DiscardPile => _discardPile;
        public Deck<TO> RemovePile => _removePile;
    }
}