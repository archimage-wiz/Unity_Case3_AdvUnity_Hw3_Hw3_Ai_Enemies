using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerProcessor : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private TowerTypes tower_type;
    [SerializeField]
    private float spawn_time = 12;
    public SpawnMenuItemsData spawn_parameters;
    private Coroutine units_spawner_coroutine;
    
    private void Awake() {
        GameLinksContainer.towers.Add(tower_type, gameObject);
    }

    void Start()
    {
        spawn_parameters = new SpawnMenuItemsData();
        spawn_parameters.tower_spawn_speed = spawn_time;
        spawn_parameters.move_speed = 0.95f;
        spawn_parameters.enemy_detect_radius = 5.1f;
        units_spawner_coroutine = StartCoroutine(UnitsSpawnCoroutine());
    }

    private IEnumerator UnitsSpawnCoroutine()
    {
        while (true)
        {
            var new_unit = Instantiate(GameLinksContainer.unit_prefab);
            new_unit.transform.SetParent(GameLinksContainer.InstantiatedObjectsContainer);
            var new_unit_script = new_unit.GetComponentInChildren<UnitProcessor>();

            new_unit_script.self_type = tower_type;
            new_unit.GetComponentInChildren<UnitBody>().GetComponent<MeshRenderer>().material = GameLinksContainer.scene_master.class_materials[(int)tower_type];

            this.transform.Rotate(0, Random.Range(-45, 45), 0);
            new_unit.transform.position = this.transform.position + this.transform.forward.normalized;

            new_unit_script.move_speed = spawn_parameters.move_speed;
            
            new_unit_script.enemy_detect_radius = spawn_parameters.enemy_detect_radius;
            yield return new WaitForSeconds(spawn_parameters.tower_spawn_speed);
        }

    }
    
    public void OnPointerClick(PointerEventData eventData) {
        GameLinksContainer.MenuAssistant.ActivateSpawnMenu(tower_type, spawn_parameters);
    }


}
