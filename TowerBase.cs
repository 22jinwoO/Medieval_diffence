using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    public int groundCnt;

    public abstract void Attack(); // abstract �κ��� ����Ŭ�������� ���� �����ϵ��� ��
}
