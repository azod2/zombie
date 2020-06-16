using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// 人類 : 移動速度、代理器、動畫控制器、死亡
/// </summary>
public class People : MonoBehaviour
{
    [Header("移動速度"), Range(0, 10)]
    public float speed = 1.5f;

    /// <summary>
    /// 導覽代理器
    /// </summary>
    protected NavMeshAgent agent;

    protected Animator ani;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        agent.speed = speed;                                                //代理器,速度=速度
    }



    public void Dead()
    {
        ani.SetTrigger("死亡");
        agent.isStopped = true;
        Destroy(gameObject, 1.5f);
    }

}
