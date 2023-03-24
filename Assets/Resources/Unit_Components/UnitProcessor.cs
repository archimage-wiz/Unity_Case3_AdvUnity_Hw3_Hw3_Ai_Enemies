using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
//using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class UnitProcessor : MonoBehaviour
{
    private Rigidbody self_rigidbody;
    private HealthBar self_healthbar;
    public GameObject target;
    [SerializeField] private LayerMask layers;
    private Coroutine self_engine;
    private LineRenderer lineRenderer;
    public TowerTypes self_type;
    public UnitModes self_mode;
    public bool target_is_enemy;
    private bool laser_draw = false;
    public float move_speed = 0.9f;
    private float FastAttackRange = 1.0f;
    private float StrongAttackMaxRange = 2.7f;
    private float StrongAttackMinRange = 1.2f;
    public float enemy_detect_radius = 5.0f;
    private int health = 100;
    private float FastAttackWeight = 1;
    private float StrongAttackWeight = 1f;


    void Start()
    {
        self_rigidbody = this.GetComponent<Rigidbody>();
        self_healthbar = GetComponentInChildren<HealthBar>();
        lineRenderer = GetComponent<LineRenderer>();
        self_mode = UnitModes.Idle;
        SceneGamePlayMaster.OnNewUnit(this);
        self_engine = StartCoroutine(Engine());
    }

    private void FollowTFleeT(bool fleee)
    {
        if (target != null)
        {
            var target_pos = target.transform.position;
            var units_distance = Vector3.Distance(transform.position, target.transform.position);

            if (units_distance >= FastAttackRange - 0.001f) { transform.position = Vector3.MoveTowards(transform.position, target_pos, move_speed * Time.deltaTime); }
            Vector3 xx = new Vector3(target_pos.x, transform.position.y, target_pos.z);
            transform.LookAt(xx);
            
        }
    }
    private void SeekT(bool flee)
    {
        bool ifound_target = false;
        Collider[] units_in_radius = Physics.OverlapSphere(transform.position, enemy_detect_radius, layers);
        if (units_in_radius.Length > 0 && flee == false)
        {
            foreach (var found_unit in units_in_radius)
            {
                var found_unit_script = found_unit.gameObject.GetComponent<UnitProcessor>();
                if (found_unit_script != null && self_type != found_unit_script.self_type)
                {
                    target = found_unit.gameObject;
                    target_is_enemy = true;
                    ifound_target = true;
                    break;
                }
            }
        }
        if (!ifound_target && target == null)
        {
            TowerTypes target_type = (TowerTypes)Random.Range(0, 3);
            if ((target_type != self_type && flee == false) || (target_type == self_type && flee == true)) {
                target = SceneGameContainer.towers[target_type];
                target_is_enemy = false;
            }
        }
    }
    private void FastAttack()
    {
        if(target != null) {
            FastAttackWeight += 0.01f;
            laser_draw = true;
            var t_scr = target.GetComponent<UnitProcessor>();
            if (t_scr != null) {
                if (t_scr) SceneGameContainer.e_proc.DamageDeal(t_scr, 12);
            }
        }
    } 
    private void StrongAttack()
    {
        if (target != null)
        {
            var bullet = Instantiate(SceneGamePlayMaster.sa_bullet_prefab);
            bullet.transform.position = transform.position + transform.forward * 0.1f;
            bullet.transform.rotation = transform.rotation;
            var bullet_script = bullet.GetComponent<StrongAttackBullet>();
            bullet_script.life_time_frames = 1250;
            bullet_script.class_ = self_type;
            StrongAttackWeight -= 10.0f;
        }
    }

    private IEnumerator Engine()
    {
        float wait_time = 1;
        while (true)
        {
            switch (self_mode)
            {
                case UnitModes.Idle:
                    self_mode = UnitModes.Stay;
                    wait_time = 1.0f;
                    break;
                case UnitModes.FollowAndSeek:
                    laser_draw = false;
                    if (target_is_enemy == false) { SeekT(false); }
                    if (target == null) { self_mode = UnitModes.Idle; break; }
                    var u_t_distance = Vector3.Distance(transform.position, target.transform.position);
                    if (u_t_distance < FastAttackRange && target_is_enemy)
                    {
                        self_mode = UnitModes.FastAttack;
                    }
                    if (u_t_distance < StrongAttackMaxRange && u_t_distance > StrongAttackMinRange && target_is_enemy) {
                        StrongAttackWeight += 0.01f;
                        if (FastAttackWeight < StrongAttackWeight) {
                            self_mode = UnitModes.StrongAttack;
                        }
                    }
                    if (health < 25) {
                        target = null;
                        target_is_enemy = false;
                        self_mode = UnitModes.Flee;
                    }
                    wait_time = 0.01f;
                    break;
                case UnitModes.Flee:
                    health += 1;
                    if (target == null) { SeekT(true); }
                    self_healthbar.SetHealthBar(health);
                    if (health > 50) {
                        target = null;
                        self_mode = UnitModes.Idle; 
                    }
                    wait_time = 0.5f;
                    break;
                case UnitModes.FastAttack:
                    if (target.gameObject != null) {
                        if (Vector3.Distance(transform.position, target.transform.position) < FastAttackRange) { FastAttack(); }
                    }
                    self_mode = UnitModes.Stay;
                    wait_time = 1.2f;
                    break;
                case UnitModes.StrongAttack:
                    if (target.gameObject != null) {
                        if (Vector3.Distance(transform.position, target.transform.position) < StrongAttackMaxRange) { StrongAttack(); }
                    }
                    self_mode = UnitModes.Stay;
                    wait_time = 5.0f;
                    break;
                case UnitModes.Stay:
                    self_mode = UnitModes.FollowAndSeek;
                    wait_time = 0.5f;
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(wait_time);
        }
    }

    void Update()
    {
        
        if (laser_draw) {
            Vector3[] positions = new Vector3[2] { transform.position, transform.position + (transform.forward * FastAttackRange) };
            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(positions);
        } else {
            lineRenderer.positionCount = 0;
        }
        
        Debug.DrawRay(transform.position, transform.forward * StrongAttackMaxRange, Color.magenta);
        if (self_mode == UnitModes.FollowAndSeek) FollowTFleeT(false);
        if (self_mode == UnitModes.Flee) FollowTFleeT(true);

        if (transform.position.y < -1)
        {
            SelfDestroy();
        }
    }
    
    public void GetDamage(int damage) {
        health -= damage;
        if (health < 0) { SelfDestroy(); } else { self_healthbar.SetHealthBar(health); }
        
    }

    private void SelfDestroy()
    {
        SceneGameContainer.scene_master.OnDestroyUnit(this);
        StopCoroutine(self_engine);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {

    }

}