using System;
using Core;
using UnityEngine;

namespace CardGames
{
    [CreateAssetMenu(menuName = "Card/Basic", fileName = "BasicCard.asset")]
    public class CardSO : ScriptableObject, IEquatable<CardSO>, ICardReference
    {
        [SerializeField] private string _name = "Default";
        [SerializeField] private string _description = "Do Nothing";
        [SerializeField] private int _cost = 0;
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

        public virtual bool Equals(CardSO other)
        {
            if (other == null)
                return false;
            return Name.Equals(other.Name, StringComparison.Ordinal);
        }

        //var card = CreateInstance<Card>();
        //Standard C#
        //AssetDatabase.CreateAsset (card, path ending in .asset);


        public virtual ICardInstance CreateInstance()
        {
            return new Card(this);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CardSO) obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

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
    
    
    
}