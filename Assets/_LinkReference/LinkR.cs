using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkR : MonoBehaviour, IDepencyProvider
{
    public static LinkR self;
    private Dictionary<Type, Component> Assistants = new Dictionary<Type, Component>();
    private Dictionary<TowerTypes, GameObject> towers = new Dictionary<TowerTypes, GameObject>(); // should be in tower provider
    
    [SerializeField] private TowerTypes twr_type;

    public Component GetDepency(Type depency_type) {
        Assistants.TryGetValue(depency_type, out Component ret_val);
        return ret_val;
    }
    
    public void RegisterAsssistant(Type assistant_type, Component assistant_component) {
        Assistants.Add(assistant_type, assistant_component);
        
    }
    
    private void Start() {
        self = this;
    }
    
    // block // should be in tower provider
    
    public void AddTower(TowerTypes type, GameObject tower) { // should be in tower provider
        towers.Add(type, tower);
    }
    public GameObject GetTower(TowerTypes target_type) {
        return towers[target_type];
    }

    
}
