using Factories.GenericStatic;
namespace AbilityDump
{
    public abstract class BaseAbility: BaseFactory
    {
        public abstract string SpriteName { get; }
        public abstract void Process();
    }
}