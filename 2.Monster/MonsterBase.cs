using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterBase : MonoBehaviour
{
    public string monsterName;
    public int startMonsterHp;
    public int monsterHp;
    public int monsterAtkDmg;
    public float monsterSpd;
    public Transform[] wayPoints;
    
    public abstract void Attack();
    public abstract void GetDamaged(int atkDmg);
    public abstract void GetNextWayPoint();
}
