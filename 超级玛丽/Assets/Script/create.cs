using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create : MonoBehaviour {

    public List<GameObject> enemy_pre_list;
    public float spawn_sepraration; //产生敌人时间间隔
    public float flying_speed;  //飞行初速度 
    private Rigidbody2D rg;
    private Vector3 forward; //投射方向

    private float spawn_timer = 0;
    void Update()
    {
        spawn_timer += Time.deltaTime;
        Random rd = new Random();
        if (spawn_timer > spawn_sepraration)
        {
            spawn_timer = 0;
            
            forward = new Vector3(1-Random.Range(0,3),Random.Range(0,3),0);
            int rand = Random.Range(0, enemy_pre_list.Count);    
            GameObject enemy=  Instantiate(enemy_pre_list[rand], transform.position, transform.rotation);
            rg = enemy.GetComponent<Rigidbody2D>();
            rg.velocity = forward * flying_speed;
        }
    }
}
