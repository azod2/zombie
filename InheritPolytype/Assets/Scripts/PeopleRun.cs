using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PeopleRun : People
{
      private  Vector3 final ;
    public float radius = 5;

    private void Update()
    {
        Flee();
    }

    /// <summary>
    /// 竄逃
    /// </summary>
    private void Flee()
    {
        if(agent.remainingDistance < 1.5f)
        {
        //隨機座標 = 隨機.球內隨機點 * 半徑 + 中心點
        Vector3 pointRun = Random.insideUnitSphere * 5 + transform.position;
        //導覽網格碰撞 碰撞點
        NavMeshHit hit;
        //導覽網格.樣本座標(座標,碰撞點,半徑,圖層)
        //out執行方法會將結果直接儲存到傳入的參數內
        //執行後會將取得的隨機點儲存在hit參數內
        NavMesh.SamplePosition(pointRun, out hit, radius, 1);
        //最終座標 = 碰撞點.座標
            final = hit.position;
        //代理器.設定目的地(座標 - 三維向量)
        }

        agent.SetDestination(final);
    }


}
