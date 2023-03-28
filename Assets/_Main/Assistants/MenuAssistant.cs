using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuAssistant : MonoBehaviour
{
    private void Start() {
        GameLinksContainer.MenuAssistant = this;
    }
    
    public void OnClickApplyButtonTowers() {
        (TowerTypes tt, SpawnMenuItemsData smid) = GameLinksContainer.spawn_menu.GetData();
        var cur_t = GameLinksContainer.towers[tt].GetComponent<TowerProcessor>();
        cur_t.spawn_parameters.tower_spawn_speed = smid.tower_spawn_speed;
        cur_t.spawn_parameters.move_speed = smid.move_speed;
        cur_t.spawn_parameters.enemy_detect_radius = smid.enemy_detect_radius;
        GameLinksContainer.spawn_menu.gameObject.SetActive(false);
    }
    
    public void ActivateSpawnMenu(TowerTypes tt, SpawnMenuItemsData spawn_params) {
        GameLinksContainer.spawn_menu.gameObject.SetActive(true);
        GameLinksContainer.spawn_menu.SetData(tt, spawn_params);
    }
    
}
