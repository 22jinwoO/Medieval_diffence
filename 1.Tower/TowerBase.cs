using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    public string unitName;
    public int groundCnt;
    public int unitPrice;
    public int unitAtkDmg;
    public float unitAtkCycle;
    public int unitAtkRange;
    public float unitMoveSpeed;

    public abstract void SearchEnemy(); // 주변의 적을 탐지하는 함수, abstract 부분은 하위클래스에서 직접 구현하도록 함
}
