using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleFarAttack : PeopleTrack
{
    [Header("停止距離"), Range(1, 10)]
    public float stop = 3f;
    [Header("子彈")]
    public GameObject bullet;

    public float cd = 1.5f;

    private float timer;
    

    protected override void Start()
    {
        agent.stoppingDistance = stop;
        target = GameObject.Find("殭屍").transform;
    }

    protected override void Track()
    {
        if (target==null)
        {
            return;                                                         //如果目標為空值 跳出
        }

        agent.SetDestination(target.position);

        transform.LookAt(target);                               //變形.看著目標

        if (agent.remainingDistance <= stop)            //如果代理器.距離 < 停止距離 就攻擊
        {
            Attack();
        }
    }

    private void Attack()
    {

        timer += Time.deltaTime;

        if (timer >=cd)
        {
            timer = 0;
        ani.SetTrigger("攻擊");
        GameObject temp =  Instantiate(bullet, transform.position+transform.forward + transform.up, transform.rotation);         //生成子彈
        Rigidbody rig =temp.AddComponent<Rigidbody>();                                       //添加元件
        rig.AddForce(transform.forward * 1500);

        }
    }


}
