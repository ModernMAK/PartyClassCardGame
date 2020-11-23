using Core;
using UnityEngine;

namespace CardGames
{
    public class UnitData : ScriptableObject, IUnitReference
    {
        [SerializeField] private string _name;
        [SerializeField] private int _maxHealth;

        public string Name
        {
            get => _name;
            protected set => _name = value;
        }
        public int MaxHealth
        {
            get => _maxHealth;
            protected set => _maxHealth = value;
        }

        public int MaxEnergy => throw new System.NotImplementedException();

        public virtual IUnitInstance CreateInstance() => new Unit(this);
    }

    public class Unit : IUnitInstance
    {
        public Unit(IUnitReference reference)
        {
            Reference = reference;
            Health = MaxHealth;
            Energy = MaxEnergy;
        }
        
        public IUnitReference Reference { get; private set; }

        public string Name => Reference.Name;

        public int MaxHealth => Reference.MaxHealth;

        public int MaxEnergy => Reference.MaxEnergy;

        public int Health { get; set; }

        public int Energy  { get; set; }
    }


    public interface IUnit
    {
        string Name { get; }
        int MaxHealth { get; }
        int MaxEnergy { get; }
    }
    public interface IUnitReference : IInstancable<IUnitInstance>, IUnit
    {
    }

    public interface IUnitInstance : IReferencable<IUnitReference>, IUnit
    {
        int Health { get; set; }
        int Energy { get; set; }
    }

}

public interface IReferencable<out T>
{
    T Reference { get; }
}
public interface IInstancable<out T>
{
    T CreateInstance();
}

/*
Cards HAVE:
    Names
    Description's
    Costs (OPT)
    Class (OPT but not really)
        Class Variants? more like something this belongs to
    Upgrades?
    Effects?
        Targets?
        Buffs/Debuffs
    

*/
/*  
Units HAVE:
    Names
    Health
        Max & Current
    Energy / Moves Remaining    
    Buffs
    
*/
