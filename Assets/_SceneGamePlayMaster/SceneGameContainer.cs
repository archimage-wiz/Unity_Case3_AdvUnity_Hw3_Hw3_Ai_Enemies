

using System.Collections.Generic;
using UnityEngine;

public static class SceneGameContainer
{

    public static InputActionBinds input_x;
    public static EventsProcessor e_proc;
    public static SceneGamePlayMaster scene_master;
    public static List<UnitProcessor> units = new List<UnitProcessor>();
    public static Dictionary<TowerTypes, GameObject> towers = new Dictionary<TowerTypes, GameObject>();
    

}
