namespace Factories.Reflection
{
    public class CloakingAbility
    {
        public class SpeedWaveAbility : BaseAbility
        {
            public override string Name{   get { return "Cloaking"; }}
            public override void Process()
            {
                // speed = 100;
            }
        }
    }
}