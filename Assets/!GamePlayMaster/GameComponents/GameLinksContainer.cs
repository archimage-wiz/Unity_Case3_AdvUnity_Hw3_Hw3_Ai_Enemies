using System.Collections.Generic;
using UnityEngine;

public static class GameLinksContainer
{
    public static InputActionBinds input_x;
    
    // assistants 
    public static EventsProcessor e_proc;
    public static SceneGamePlayMaster scene_master;
    public static DestroyUnitAssistant DestroyUnitAssistant;
    public static CreateUnitAssistant CreateUnitAssistant;
    public static MenuAssistant MenuAssistant;
    
    // game units list
    public static List<UnitProcessor> units = new List<UnitProcessor>();
    public static Dictionary<TowerTypes, GameObject> towers = new Dictionary<TowerTypes, GameObject>();
    
    // prefabs
    public static GameObject unit_prefab;
    public static GameObject sa_bullet_prefab;
    
    // Game objects
    public static SpawnUnitsMenu spawn_menu;
    public static Transform InstantiatedObjectsContainer;
    
    static GameLinksContainer()
    {
        input_x ??= new InputActionBinds();
        input_x.Enable();
        
        unit_prefab = (GameObject)Resources.Load("GameObjects/Unit");
        sa_bullet_prefab = (GameObject)Resources.Load("GameObjects/StrongAttackBullet");
        
    }
    
    static void AnotherOverallStaticMethod()
    {
        // Need ?
    }
    
}
