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

        public string Name
        {
            get => _name;
            protected set => _name = value; 
        }

        public string Description 
        {
            get => _description;
            protected set => _description = value; 
        }
        public int Cost
        {
            get => _cost;
            protected set => _cost = value; 
        }
        public Sprite Graphic 
        {
            get => _graphic;
            protected set => _graphic = value; 
        }

        public virtual bool Equals(Card other)
        {
            if (other == null)
                return false;
            return Name.Equals(other.Name, StringComparison.Ordinal);
        }

        public virtual ICard DeepClone()
        {
            var card = CreateInstance<Card>();
            card.Name = _name;
            card.Description = _description;
            card.Cost = _cost;
            card.Graphic = _graphic;
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
}