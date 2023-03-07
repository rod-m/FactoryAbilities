namespace Factories.Reflection
{
    public class HealAbility : BaseAbility
    {
        public override string Name{   get { return "Heal"; }}
        // newer versions of Visual Studio Support this => shortcut for the above
        //public override string Name => "fire";

        public override void Process()
        {
         
        }
    }
}