using AbilityDump;
using UnityEngine;
// using Factories.Static;
using Factories.GenericStatic;

public class AbilityPanel : MonoBehaviour
{
    [SerializeField] private AbilityButton buttonPrefab;

    private void OnEnable()
    {
        foreach (string name in GenericStaticFactory<BaseAbility>.GetComponentNames())
        {
            var btn = Instantiate(buttonPrefab);
            btn.gameObject.name = name + " Button";
            
            btn.SetAbilityName(name);
            btn.transform.SetParent(transform);
        }
        
    }
}
