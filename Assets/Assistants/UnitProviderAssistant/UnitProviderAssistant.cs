using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProviderAssistant : MonoBehaviour, IDestroyUnit, INewUnit
{
    private IDepencyProvider _dep = LinkR.self;
    private List<UnitProcessor> units = new List<UnitProcessor>();
    
    void Start() {
        _dep = LinkR.self;
        _dep.RegisterAsssistant(typeof(IDestroyUnit), this);
        _dep.RegisterAsssistant(typeof(INewUnit), this);
    }
    
    public void OnNewUnit(Component component_script) {
        units.Add((UnitProcessor)component_script);
    }
    public void OnDestroyUnit(Component unit_script)
    {
        units.Remove((UnitProcessor)unit_script);
        print("Removed unit from db");
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
