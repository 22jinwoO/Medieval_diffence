using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalMonster : MonsterBase
{
    [SerializeField]
    GameManager gmCs;
    Transform target;

    int wavePointIndex=0;

    private void Awake()
    {
        wayPoints = gmCs.stg1WayPoints;
        for (int i = 0; i < gmCs.stg1WayPoints.Length; i++)
        {
            wayPoints[i] = gmCs.stg1WayPoints[i];
        }
        target = wayPoints[0];
    }
    void Start()
    {
        monsterName = "노말몬스터";
        monsterHp = 500;
        monsterSpd = 3;
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
        
        
        nav.SetDestination(target.position);
    }

    void Update()
    {
        
        
        if (Vector3.Distance(transform.position, target.position) <= 1f)
        {
            GetNextWayPoint();
        }
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void GetNextWayPoint()  // 다음 포인트 지점을 알려주는 함수
    {
        if (wayPoints.Length >= wavePointIndex - 1)
        {
            wavePointIndex++;
            target = wayPoints[wavePointIndex];

            transform.LookAt(target);
            nav.velocity = Vector3.zero;
            nav.SetDestination(target.position);
            
        }
        
    }
}
