using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
namespace Factories.Static
{
    public abstract class BaseAbility
    {
        public abstract string Name { get; }
        public abstract void Process();
    }

    public class HealAbility : BaseAbility
    {
        public override string Name{   get { return "Heal"; }}
        // newer versions of Visual Studio Support this => shortcut for the above
        //public override string Name => "fire";

        public override void Process()
        {
            var player = GameObject.FindObjectOfType<PlayerNav>();
            Debug.Log("Ability : " + Name);
            player.ShowParticle(0);
        }
    }
  

    public static class AbilityFactory
    {
        private static Dictionary<string, Type> abilitiesByName;
        private static bool IsInitialised = false;
        private static void InitialiseFactory()
        {
            if(IsInitialised) 
                return;
            
            var abilityTypes = Assembly.GetAssembly(typeof(BaseAbility)).GetTypes()
                .Where( myType => myType.IsClass && ! myType.IsAbstract && myType.IsSubclassOf(typeof(BaseAbility)));
            // Dictionary for finding these by name later (could be an enum/id instead of string)
            abilitiesByName = new Dictionary<string, Type>();
            foreach (var type in abilityTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as BaseAbility;
                abilitiesByName.Add(tempEffect.Name, type);
            }

            IsInitialised = true;
        }

        public static BaseAbility GetAbility(string abilityType)
        {
            InitialiseFactory();
            if (abilitiesByName.ContainsKey(abilityType))
            {
                Type type = abilitiesByName[abilityType];
                var ability = Activator.CreateInstance(type) as BaseAbility;
                return ability;
            }

            return null;
        }

        internal static IEnumerable<string> GetAbilityNames()
        {
            InitialiseFactory();
            return abilitiesByName.Keys;
        }
    }
}