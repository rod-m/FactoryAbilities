using UnityEngine;

namespace Factories.Static
{
    public class HealAbility : BaseAbility
    {
        public override string Name => "Heal";
        // newer versions of Visual Studio Support this => shortcut for the above
        //public override string Name => "fire";

        public override void Process()
        {
            var player = GameObject.FindObjectOfType<PlayerNav>();
            Debug.Log("Ability : " + Name);
            player.ShowParticle(0);
        }
    }
}