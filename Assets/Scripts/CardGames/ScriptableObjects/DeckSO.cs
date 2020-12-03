using UnityEngine;

namespace CardGames
{
    [CreateAssetMenu(menuName="Deck/Empty",fileName = "Deck.asset")]
    public class DeckSO : ScriptableObject, IInstancable<Deck<ICardReference>>
    {
        [SerializeField] private CardSO[] _cards;
        [Min(1)]
        [SerializeField] private int _copies = 1;

        public Deck<ICardReference> CreateInstance()
        {
            var d = new Deck<ICardReference>();
            foreach (var card in _cards)
                for(var i = 0; i < _copies; i++)
                    d.Add(card);
            return d;
        }
    }
}