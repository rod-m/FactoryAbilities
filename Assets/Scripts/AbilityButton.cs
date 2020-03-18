using DefaultNamespace;
using UnityEngine;
using Factories.Static;
using UnityEngine.UI;
public class AbilityButton : MonoBehaviour, AbilityInterface
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
        ability = AbilityFactory.GetAbility(name);
    }
}
