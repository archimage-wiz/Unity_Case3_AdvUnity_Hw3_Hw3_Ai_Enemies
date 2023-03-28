using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// deprecaed 

public static class GameLinksContainer
{
    public static InputActionBinds input_x;
    
    
    public static EventsProcessor e_proc; // should be assistant

    public static MenuAssistant MenuAssistant;
    
    // game units list
    
    public static Dictionary<TowerTypes, GameObject> towers = new Dictionary<TowerTypes, GameObject>();
    
    // prefabs

    
    // Game objects
    public static SpawnUnitsMenu spawn_menu;
    public static Transform InstantiatedObjectsContainer;
    
    static GameLinksContainer()
    {
        input_x ??= new InputActionBinds();
        input_x.Enable();
        

        
    }
    

    
}
