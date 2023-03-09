using UnityEngine;
namespace AbilityDump 
{
    public class SpeedWaveAbility : BaseAbility
    {
        public override string Name => "Speed Wave";

        public override string SpriteName => "SpeedWave";

        public override void Process()
        {
           
            var player = GameObject.FindObjectOfType<PlayerNav>();
            Debug.Log("Ability : " + Name);
            player.Speed = 40;
            
        }
        
    }
}