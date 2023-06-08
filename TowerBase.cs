using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    public int groundCnt;

    public abstract void Attack(); // abstract 부분은 하위클래스에서 직접 구현하도록 함
}
