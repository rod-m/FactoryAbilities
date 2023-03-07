using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Factories.Reflection
{
    public class AbilityFactory
    {
        private Dictionary<string, Type> abilitiesByName;
        public AbilityFactory()
        {
            var abilityTypes = Assembly.GetAssembly(typeof(BaseAbility)).GetTypes()
                .Where( myType => myType.IsClass && ! myType.IsAbstract && myType.IsSubclassOf(typeof(BaseAbility)));
            // Dictionary for finding these by name later (could be an enum/id instead of string)
            abilitiesByName = new Dictionary<string, Type>();
            foreach (var type in abilityTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as BaseAbility;
                abilitiesByName.Add(tempEffect.Name, type);
            }
        }

        public BaseAbility GetAbility(string abilityType)
        {
            if (abilitiesByName.ContainsKey(abilityType))
            {
                Type type = abilitiesByName[abilityType];
                var ability = Activator.CreateInstance(type) as BaseAbility;
                return ability;
            }

            return null;
        }

        internal IEnumerable<string> GetAbilityNames()
        {
            return abilitiesByName.Keys;
        }
    }
}