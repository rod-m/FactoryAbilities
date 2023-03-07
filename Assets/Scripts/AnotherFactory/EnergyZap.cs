using UnityEngine;

namespace DefaultNamespace.AnotherFactory
{
    public class EnergyZap: BaseHandicap
    {
        public override string Name => "Energy Zap";
        public override void Process()
        {
            Debug.Log("Energy zapping!!!");
        }
    }
}