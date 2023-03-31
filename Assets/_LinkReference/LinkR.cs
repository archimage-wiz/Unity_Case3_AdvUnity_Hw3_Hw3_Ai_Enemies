using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkR : MonoBehaviour
{
    public static LinkR self;
    private static Dictionary<Type, Component> Assistants = new Dictionary<Type, Component>();
    private static Dictionary<TowerTypes, GameObject> towers = new Dictionary<TowerTypes, GameObject>(); // should be in tower provider
    
    [SerializeField] private TowerTypes twr_type;

    public static Component GetDepency(Type depency_type) {
        Assistants.TryGetValue(depency_type, out Component ret_val);
        return ret_val;
    }
    
    public static void RegisterAsssistant(Type assistant_type, Component assistant_component) {
        Assistants.Add(assistant_type, assistant_component);
        
    }
    
    private void Start() {
        self = this;
    }
    
    public static void AddTower(TowerTypes type, GameObject tower) { // should be in tower provider
        towers.Add(type, tower);
    }
    public static GameObject GetTower(TowerTypes target_type) {
        return towers[target_type];
    }

    
}
