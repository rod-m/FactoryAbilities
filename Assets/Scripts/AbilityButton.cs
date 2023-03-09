using DefaultNamespace;
using UnityEngine;
using Factories.GenericStatic;
using AbilityDump;
using UnityEngine.UI;
public class AbilityButton : MonoBehaviour, IAbilityUse
{
    private BaseAbility ability;
    private Sprite sprite;
    public void UseAbility()
    {
        Debug.Log($"Using ability {ability.Name}");
        ability.Process();
    }
    public void SetAbilityName(string name)
    {
        this.GetComponentInChildren<Text>().text = name;
        ability = GenericStaticFactory<BaseAbility>.GetComponentTypeByName(name) as BaseAbility;
        SetButtonImage(ability.SpriteName);
    }

    void SetButtonImage(string name)
    {
        // use a sprite name here
        sprite = Resources.Load(name, typeof(Sprite)) as Sprite;
        Image img = GetComponent<Image>();
        if (img == null)
        {
            Debug.Log("Cant get Image component!");
            return;
        }
        
        img.sprite = sprite;
        //img.color = Color.green;
    }
}
