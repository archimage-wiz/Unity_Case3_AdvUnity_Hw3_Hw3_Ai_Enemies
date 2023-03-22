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
        //StartCorouinez();
    }

    private void StartCorouinez()
    {
        //targets_game_play_coroutine = StartCoroutine(UnitsTargetsCoroutine());
    }
    private void StopCoroutinez()
    {
        StopCoroutine(targets_game_play_coroutine);
    }

    public void OnDestroyUnit(UnitProcessor x)
    {
        SceneGameContainer.units.Remove(x);
        foreach (var unit in SceneGameContainer.units)
        {
            //print(unit.target + " " + x);
            if (unit.target == x.gameObject)
            {
                //print("Remved target from " + unit);
                unit.target = null;
                unit.target_is_enemy = false;
                unit.self_mode = UnitModes.Idle;
            }
        }
    }
    
    public static void OnNewUnit(UnitProcessor x) {
        SceneGameContainer.units.Add(x);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {

    }

}
