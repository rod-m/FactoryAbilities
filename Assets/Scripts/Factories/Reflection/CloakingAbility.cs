namespace Factories.Reflection
{
    public class CloakingAbility
    {
        public class SpeedWaveAbility : BaseAbility
        {
            public override string Name => "Cloaking";

            public override void Process()
            {
                // speed = 100;
            }
        }
    }
}