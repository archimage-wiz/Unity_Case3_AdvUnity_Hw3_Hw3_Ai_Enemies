using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProcessor : MonoBehaviour
{
    [SerializeField]
    private TowerTypes tower_type;
    [SerializeField]
    private float spawn_time = 10;

    private Coroutine units_spawner_coroutine;
    
    private void Awake() {
        SceneGameContainer.towers.Add(tower_type, gameObject);
    }

    void Start()
    {
        
        units_spawner_coroutine = StartCoroutine(UnitsSpawnCoroutine());
    }

    private IEnumerator UnitsSpawnCoroutine()
    {
        while (true)
        {
            var new_unit = Instantiate(SceneGamePlayMaster.unit_prefab);
            var new_unit_script = new_unit.GetComponentInChildren<UnitProcessor>();

            new_unit_script.self_type = tower_type;
            new_unit.GetComponentInChildren<UnitBody>().GetComponent<MeshRenderer>().material = SceneGameContainer.scene_master.class_materials[(int)tower_type];

            this.transform.Rotate(0, Random.Range(-45, 45), 0);
            new_unit.transform.position = this.transform.position + this.transform.forward.normalized;
            

            yield return new WaitForSeconds(spawn_time);
        }

    }

    private void OnDestroy()
    {
        //StopCoroutine(units_spawner_coroutine);
    }
}
