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

    public abstract void SearchEnemy(); // �ֺ��� ���� Ž���ϴ� �Լ�, abstract �κ��� ����Ŭ�������� ���� �����ϵ��� ��
}
