using UnityEngine;

namespace Factories.Static
{
    public class SpeedWaveAbility : BaseAbility
    {
        public override string Name{   get { return "Speed Wave"; }}
        public override void Process()
        {
           
            var player = GameObject.FindObjectOfType<PlayerNav>();
            Debug.Log("Ability : " + Name);
            player.Speed = 40;
            
        }
        
    }
}