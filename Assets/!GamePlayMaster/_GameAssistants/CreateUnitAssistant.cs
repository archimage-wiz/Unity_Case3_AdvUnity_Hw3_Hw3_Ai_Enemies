using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnitAssistant : MonoBehaviour
{
    void Start()
    {
        GameLinksContainer.CreateUnitAssistant = this;
    }
    public void OnNewUnit(UnitProcessor unit_script) {
        GameLinksContainer.units.Add(unit_script);
    }

}
