namespace Factories.Simple
{
    public class AbilityFactory
    {
        public BaseAbility GetAbility(string abilityType)
        {
            switch (abilityType)
            {
                case "speed":
                    return new SpeedWaveAbility();
                default:
                    return new CommonAbility();
            }
        }
    }
}