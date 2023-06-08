using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterBase : MonoBehaviour
{
    public string monsterName;
    public int monsterHp;
    public float monsterSpd;
    public Transform[] wayPoints;
    public NavMeshAgent nav;
    
    public abstract void Attack();
    public abstract void GetNextWayPoint();
}
