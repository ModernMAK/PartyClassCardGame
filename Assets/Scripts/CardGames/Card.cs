using System;
using System.Globalization;
using Localization;

namespace CardGames
{
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
}