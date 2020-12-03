using UnityEngine;

namespace CardGames
{
    public class Card : ICardInstance
    {
        public Card(ICardReference reference)
        {
            Reference = reference;
            Cost = Reference.Cost;
        }
        
        public ICardReference Reference { get; private set; }
        public string Name => Reference.Name;
        public string Description => Reference.Description;
        public int Cost { get; set; }
        public Sprite Graphic => Reference.Graphic;
    }

    public class UniversalCard : Card, IUniversalCardInstance<IUnitInstance>
    {
        public UniversalCard(ICardReference reference) : base(reference)
        {
        }

        public IAttack<IUnitInstance> AttackAffect { get; set; }

        public IDefense<IUnitInstance> DefenseAffect { get; set; }
    }
}