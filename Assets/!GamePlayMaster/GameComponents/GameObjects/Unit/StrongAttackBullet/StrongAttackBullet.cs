using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAttackBullet : MonoBehaviour
{
    public TowerTypes class_;
    public int life_time_frames = 0;
    public float bullet_speed = 2;
    public GameObject source;
    public GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        //print("Bullet start");
    }
    
    private void OnTriggerEnter(Collider x) {
        if (x.gameObject == null) return;
        var x_scr = x.gameObject.GetComponent<UnitProcessor>();
        if (x_scr == null) return;
        if (x_scr.self_type == class_) return;
        GameLinksContainer.e_proc.DamageDeal(x_scr, 23);
    }

    // Update is called once per frame
    void Update()
    {
        life_time_frames -= 1;
        if (life_time_frames < 0) {
            Destroy(gameObject);
        }
        transform.position += bullet_speed * Time.deltaTime * transform.forward;
    }
}
