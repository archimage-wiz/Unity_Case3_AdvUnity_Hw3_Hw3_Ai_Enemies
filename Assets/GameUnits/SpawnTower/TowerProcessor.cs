using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using System;
using UnityEngine;
using UnityEngine.EventSystems;



public class TowerProcessor : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Material[] class_materials; 
    [SerializeField] private TowerTypes tower_type;
    [SerializeField] private float spawn_time = 12;
    public SpawnMenuItemsData spawn_parameters;
    private Coroutine units_spawner_coroutine;
    
    private void Awake() {
        LinkR.AddTower(tower_type, gameObject);
    }

    void Start()
    {
        spawn_parameters = new SpawnMenuItemsData();
        spawn_parameters.tower_spawn_speed = spawn_time;
        spawn_parameters.move_speed = 0.95f;
        spawn_parameters.enemy_detect_radius = 5.1f;
        units_spawner_coroutine = StartCoroutine(UnitsSpawnCoroutine());
        // var x = FindObjectsOfType<MonoBehaviour>();
        // print(x.Length + " : " + x.OfType<INewUnit>().ToList()[0]);
    }

    private IEnumerator UnitsSpawnCoroutine()
    {
        while (true)
        {
            var new_unit = Instantiate(((IGameResourceProvider)LinkR.GetDepency(typeof(IGameResourceProvider)))?.GetGameObject("Unit"));
            new_unit.transform.SetParent(GameLinksContainer.InstantiatedObjectsContainer);
            var new_unit_script = new_unit.GetComponentInChildren<UnitProcessor>();
            ((INewUnit)LinkR.GetDepency(typeof(INewUnit)))?.OnNewUnit(new_unit_script);

            new_unit_script.self_type = tower_type;
            new_unit.GetComponentInChildren<UnitBody>().GetComponent<MeshRenderer>().material = class_materials[(int)tower_type];

            this.transform.Rotate(0, UnityEngine.Random.Range(-45, 45), 0);
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

