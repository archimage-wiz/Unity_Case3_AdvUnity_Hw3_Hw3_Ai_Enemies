using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUnitAssistant : MonoBehaviour
{
    void Start()
    {
        GameLinksContainer.DestroyUnitAssistant = this;
    }

    public void OnDestroyUnit(UnitProcessor unit_script)
    {
        GameLinksContainer.units.Remove(unit_script);
        foreach (var unit in GameLinksContainer.units)
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
