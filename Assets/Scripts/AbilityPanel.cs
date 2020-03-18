using UnityEngine;
using Factories.Static;
public class AbilityPanel : MonoBehaviour
{
    [SerializeField] private AbilityButton buttonPrefab;
    // Start is called before the first frame update
    private void OnEnable()
    {
        foreach (string name in AbilityFactory.GetAbilityNames())
        {
            var btn = Instantiate(buttonPrefab);
            btn.gameObject.name = name + " Button";
            
            btn.SetAbilityName(name);
            btn.transform.SetParent(transform);
        }
        
    }
}
