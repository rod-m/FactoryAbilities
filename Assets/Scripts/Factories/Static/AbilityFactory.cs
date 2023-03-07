using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Factories.Static
{
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