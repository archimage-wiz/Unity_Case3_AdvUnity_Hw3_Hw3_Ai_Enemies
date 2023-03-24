using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float health_bar_cell = 0.5f;
    
    private void Start() {
        transform.localScale = new Vector3(health_bar_cell, 0.05f, 0.001f);
    }

    public void SetHealthBar(int x) {

        transform.localScale = new Vector3(x * health_bar_cell / 100, 0.05f, 0.001f);
        
    }

}
