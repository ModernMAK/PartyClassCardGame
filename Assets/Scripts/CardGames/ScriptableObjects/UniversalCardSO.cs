using System;
using Core;
using UnityEngine;

namespace CardGames
{
    [CreateAssetMenu(menuName = "Card/Universal", fileName = "BasicCard.asset")]
    public class UniversalCardSO : CardSO, IEquatable<UniversalCardSO>
    {
        [Header("Attack Data")] private int RawDamage;
        private bool HasAttackData => RawDamage != 0;

        private IAttack<IUnitInstance> CreateAttackInstance()
        {
            return new SimpleAttack() {BaseDamage = RawDamage};
        }
        [Header("Defense Data")] private int RawDefense;
        private bool HasDefenseData => RawDefense != 0;

        private IDefense<IUnitInstance> CreateDefenseInstance()
        {
            return new SimpleDefense() {BaseDefense = RawDamage};
        }


        public virtual bool Equals(UniversalCardSO other)
        {
            if (other == null)
                return false;
            return Name.Equals(other.Name, StringComparison.Ordinal);
        }


        public override ICardInstance CreateInstance()
        {
            return new UniversalCard(this)
            {
                AttackAffect = HasAttackData ? CreateAttackInstance() : null,
                DefenseAffect = HasDefenseData ? CreateDefenseInstance() : null

            };
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UniversalCardSO) obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}