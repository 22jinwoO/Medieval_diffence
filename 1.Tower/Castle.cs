using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    int castleStartHp = 100;
    int castleHp = 100;
    [SerializeField]
    Image castleHpBar;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CastleGetDamaged(int atkDmg)
    {
        castleHp-=atkDmg;
        castleHpBar.fillAmount = (float)castleHp / (float)castleStartHp;
    }
}
