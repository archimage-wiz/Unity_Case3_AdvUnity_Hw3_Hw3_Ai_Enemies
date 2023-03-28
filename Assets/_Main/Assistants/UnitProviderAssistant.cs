using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProviderAssistant : MonoBehaviour, INewUnit, IDestroyUnit
{
    private List<UnitProcessor> units = new List<UnitProcessor>();
    
    void Start() {
        AssistantsContainer.RegisterAsssistant(typeof(IDestroyUnit), this);
        AssistantsContainer.RegisterAsssistant(typeof(INewUnit), this);
    }
    
    public void OnNewUnit(Component component_script) {
        units.Add((UnitProcessor)component_script);
    }
    public void OnDestroyUnit(Component unit_script)
    {
        units.Remove((UnitProcessor)unit_script);
        foreach (var unit in units)
        {
            if (unit.target == unit_script.gameObject)
            {
                unit.target = null;
                unit.target_is_enemy = false;
                unit.self_mode = UnitModes.Idle;
            }
        }
    }
}
