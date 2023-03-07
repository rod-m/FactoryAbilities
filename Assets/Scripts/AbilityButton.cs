using DefaultNamespace;
using UnityEngine;
using Factories.GenericStatic;
using AbilityDump;
using UnityEngine.UI;
public class AbilityButton : MonoBehaviour, IAbilityUse
{
    private BaseAbility ability;
 
    public void UseAbility()
    {
        Debug.Log("Using ability ");
        ability.Process();
    }
    public void SetAbilityName(string name)
    {
        this.GetComponentInChildren<Text>().text = name;
        ability = GenericStaticFactory<BaseAbility>.GetComponentTypeByName(name) as BaseAbility;
    }
}
