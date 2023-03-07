using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Factories.GenericStatic
{
    public class GenericStaticFactory<T> where T : BaseFactory
    {
        private static Dictionary<string, Type> componentByName;
        private static bool IsInitialised = false;
        private static void InitialiseFactory()
        {
            if(IsInitialised) 
                return;
            IsInitialised = true;
            Debug.Log($"InitialiseFactory!");
            var componentsByType = Assembly.GetAssembly(typeof(BaseFactory)).GetTypes()
                .Where( myType => myType.IsClass && ! myType.IsAbstract && myType.IsSubclassOf(typeof(BaseFactory)));
            // Dictionary for finding these by name later (could be an enum/id instead of string)
            componentByName = new Dictionary<string, Type>();
            foreach (var type in componentsByType)
            {
                var tempEffect = Activator.CreateInstance(type) as T;
                
                if(tempEffect == null) continue;
                Debug.Log($"I am a {tempEffect.Name}");
                componentByName.Add(tempEffect.Name, type);
            }
        }

        public static BaseFactory GetComponentTypeByName(string typeName)
        {
            InitialiseFactory();
            if (componentByName.ContainsKey(typeName))
            {
                Type type = componentByName[typeName];
                var ability = Activator.CreateInstance(type) as BaseFactory;
                return ability as T;
            }
            return null;
        }

        internal static IEnumerable<string> GetComponentNames()
        {
            InitialiseFactory();
            return componentByName.Keys;
        }
    }
}