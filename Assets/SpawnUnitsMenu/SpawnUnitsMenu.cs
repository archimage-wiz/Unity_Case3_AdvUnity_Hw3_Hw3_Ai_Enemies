using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnitsMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField spawn_speed_val_text;
    [SerializeField] private TMP_InputField enemy_detection_radius_text;
    [SerializeField] private TMP_InputField move_speed_text;
    private TowerTypes tower_type;

    public (TowerTypes, SpawnMenuItemsData) GetData() {
        var ret_val = new SpawnMenuItemsData();

        ret_val.tower_spawn_speed = (float)Convert.ToDouble(spawn_speed_val_text.text.Replace('.', ','));
        ret_val.enemy_detect_radius = float.Parse(enemy_detection_radius_text.text.Replace('.', ','));
        ret_val.move_speed = (float)Convert.ToDouble(move_speed_text.text.Replace('.', ','));
        return (tower_type, ret_val);
    }
    
    public void SetData(TowerTypes tt, SpawnMenuItemsData smid) {
        spawn_speed_val_text.text = smid.tower_spawn_speed.ToString();
        enemy_detection_radius_text.text = smid.enemy_detect_radius.ToString();
        move_speed_text.text = smid.move_speed.ToString();
        tower_type = tt;
    }
}
