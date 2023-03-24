using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SceneGamePlayMaster : MonoBehaviour
{
    public EventsProcessor e_proc;
    public Material[] class_materials;
    public static GameObject unit_prefab;
    public static GameObject sa_bullet_prefab;
    private Coroutine targets_game_play_coroutine;
    public SpawnUnitsMenu spawn_menu;


    private void Awake()
    {
        SceneGameContainer.scene_master = this;
        SceneGameContainer.e_proc = e_proc;
        SceneGameContainer.input_x ??= new InputActionBinds();
        SceneGameContainer.input_x.Enable();
        unit_prefab = (GameObject)Resources.Load("Unit_Components/Unit");
        sa_bullet_prefab = (GameObject)Resources.Load("Unit_Components/StrongAttackBullet/StrongAttackBullet");
    }

    void Start()
    {
        spawn_menu.gameObject.SetActive(false);
    }


    public void OnDestroyUnit(UnitProcessor x)
    {
        SceneGameContainer.units.Remove(x);
        foreach (var unit in SceneGameContainer.units)
        {
            if (unit.target == x.gameObject)
            {
                unit.target = null;
                unit.target_is_enemy = false;
                unit.self_mode = UnitModes.Idle;
            }
        }
    }
    
    public static void OnNewUnit(UnitProcessor x) {
        SceneGameContainer.units.Add(x);
    }

    public void OnClickApplyButtonTowers() {
        (TowerTypes tt, SpawnMenuItemsData smid) = spawn_menu.GetData();
        var cur_t = SceneGameContainer.towers[tt].GetComponent<TowerProcessor>();
        cur_t.spawn_parameters.tower_spawn_speed = smid.tower_spawn_speed;
        cur_t.spawn_parameters.move_speed = smid.move_speed;
        cur_t.spawn_parameters.enemy_detect_radius = smid.enemy_detect_radius;
        spawn_menu.gameObject.SetActive(false);
    }
    
    public void ActivateSpawnMenu(TowerTypes tt, SpawnMenuItemsData spawn_params) {
        spawn_menu.gameObject.SetActive(true);
        spawn_menu.SetData(tt, spawn_params);
    }
    

    private void OnDestroy()
    {

    }

}
