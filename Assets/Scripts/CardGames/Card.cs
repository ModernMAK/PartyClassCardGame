using System;
using System.Globalization;
using Localization;

namespace CardGames
{
    [Serializable]
    public struct CardData
    {
        public readonly string Name;
        public readonly string Description;
        public readonly int Cost;

        public CardData(string name, string description, int cost)
        {
            Name = name;
            Description = description;
            Cost = cost;
        }
    }

    public class Card : IEquatable<Card>
    {
        private readonly string _unlocalizedName;

        public Card(string unlocalizedName)
        {
            _unlocalizedName = unlocalizedName;
        }

        public string UnlocalizedName => _unlocalizedName;
        public string Name => GetName(CultureInfo.CurrentUICulture);
        public string GetName(CultureInfo cultureInfo) => Cards.ResourceManager.GetString(UnlocalizedName, cultureInfo);

        public virtual bool Equals(Card other)
        {
            if (other == null)
                return false;
            return UnlocalizedName.Equals(other.UnlocalizedName, StringComparison.Ordinal);
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
            return _unlocalizedName.GetHashCode();
        }
    }

    public class CardBuilder
    {
        public string UnlocalizedName { get; set; }

        public CardBuilder SetUnlocalizedName(string value)
        {
            UnlocalizedName = value;
            return this;
        }

        public Card Create()
        {
            return new Card(UnlocalizedName);
        }
    }
}