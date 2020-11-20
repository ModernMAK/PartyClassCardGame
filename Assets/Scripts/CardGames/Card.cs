using System;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace CardGames
{
    [CreateAssetMenu(menuName = "Card/Basic", fileName = "BasicCard.asset")]
    public class Card : ScriptableObject, IEquatable<Card>, ICard
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private int _cost;
        [SerializeField] private Sprite _graphic;

        public string Name => _name;
        public string Description => _description;
        public int Cost => _cost;
        public Sprite Graphic => _graphic;

        public virtual bool Equals(Card other)
        {
            if (other == null)
                return false;
            return Name.Equals(other.Name, StringComparison.Ordinal);
        }

        public ICard DeepClone()
        {
            var card = CreateInstance<Card>();
            card._name = _name;
            card._description = _description;
            card._cost = _cost;
            card._graphic = _graphic;
            return card;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        object IDeepCloneable.DeepClone()
        {
            return DeepClone();
        }
    }

    public interface ICard : IDeepCloneable<ICard>
    {
        string Name { get; }
        string Description { get; }
        int Cost { get; }
        Sprite Graphic { get; }
        
    }
}