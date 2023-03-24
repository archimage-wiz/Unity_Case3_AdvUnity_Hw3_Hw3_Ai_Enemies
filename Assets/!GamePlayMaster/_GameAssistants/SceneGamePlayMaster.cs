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
    // public static GameObject unit_prefab;
    // public static GameObject sa_bullet_prefab;
    // private Coroutine targets_game_play_coroutine;
    // public SpawnUnitsMenu spawn_menu;


    void Start()
    {
        GameLinksContainer.scene_master = this;
    }



}
