namespace CardGames
{
    public class PlayerField<T>
    {
        private readonly Deck<T> _drawPile;
        private readonly Deck<T> _discardPile;
        private readonly Deck<T> _removePile;
        private readonly Hand<T> _hand;

        public PlayerField(Deck<T> drawPile) : this(drawPile, new Hand<T>(), new Deck<T>(), new Deck<T>())
        {
            //Assume discard pile and remove pile are empty decks
        }

        public PlayerField(Deck<T> drawPile, Hand<T> hand, Deck<T> discardPile, Deck<T> removePile)
        {
            _drawPile = drawPile;
            _hand = hand;
            _discardPile = discardPile;
            _removePile = removePile;
        }

        public Hand<T> Hand => _hand;
        public Deck<T> DrawPile => _drawPile;
        public Deck<T> DiscardPile => _discardPile;
        public Deck<T> RemovePile => _removePile;
    }
}