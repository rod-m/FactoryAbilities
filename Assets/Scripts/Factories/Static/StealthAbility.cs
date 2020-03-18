using UnityEngine;

namespace Factories.Static
{
    public class StealthAbility : BaseAbility
    {
    
        public override string Name{   get { return "Stealth"; }}
        public override void Process()
        {
            Debug.Log("Ability : " + Name);
            var player = GameObject.FindObjectOfType<PlayerNav>();
            player.ShowParticle(2);
        }
    }
}