using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventsProcessor : MonoBehaviour
{
    
    private void Start() {
        GameLinksContainer.e_proc = this;
    }
    
    public void DamageDeal(UnitProcessor UnitScript, int damage) {
        if (UnitScript.gameObject.activeSelf) {
            UnitScript.GetDamage(damage);
        }
    }
    
}
