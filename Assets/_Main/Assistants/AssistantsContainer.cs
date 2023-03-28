using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AssistantsContainer
{
    private static Dictionary<Type, Component> Assistants = new Dictionary<Type, Component>();

    public static Component GetDepency(Type depency_type) {
        Assistants.TryGetValue(depency_type, out Component ret_val);
        return ret_val;
    }
    
    public static void RegisterAsssistant(Type assistant_type, Component assistant_component) {
        Assistants.Add(assistant_type, assistant_component);
        
    }
    
}
