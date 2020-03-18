using System.Collections;
using System.Collections.Generic;

namespace Factories.Simple
{
    
    public abstract class BaseAbility
    {
        public abstract void Process();
    }

    public class CommonAbility : BaseAbility
    {
        public override void Process()
        {
           
        }
    }
    public class SpeedWaveAbility : BaseAbility
    {
        public override void Process()
        {
           // speed = 100;
        }
    }

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
