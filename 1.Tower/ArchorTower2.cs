using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchorTower2 : TowerBase
{
    [SerializeField]
    Transform normalTower = null;

    [SerializeField]
    LayerMask layerMask = 0;

    Transform target = null;

    [SerializeField]
    Animator anim;

    [SerializeField]
    float atkDelay = 0;
    public bool _isCanAtk;

    // Start is called before the first frame update
    void Start()
    {
        unitName = "궁수(2단계)";
        groundCnt = 4;
        unitPrice = 200;
        unitAtkDmg = 10;
        unitAtkCycle = 1.5f;
        unitAtkRange = 50;
        unitMoveSpeed = 1.5f;
        InvokeRepeating("SearchEnemy", 0f, 0.5f);
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (_isCanAtk)
        {
            if (atkDelay <= unitAtkCycle)
            {
                atkDelay += Time.deltaTime;

            }

            else if (target != null && atkDelay >= unitAtkCycle)
            {
                anim.SetTrigger("canAtkTrigger");
                target.SendMessage("GetDamaged", unitAtkDmg);
                Debug.Log("적 탐색 완료");
                Vector3 dir = target.transform.position - transform.position;


                Quaternion rot = Quaternion.LookRotation(dir.normalized);

                transform.rotation = rot;
                atkDelay = 0;


            }
        }

    }
    public override void SearchEnemy()  //주변의 적을 탐지하는 함수
    {
        Collider[] t_cols = Physics.OverlapSphere(transform.position, unitAtkRange, layerMask);
        Transform nearTarget = null;

        if (t_cols.Length > 0)
        {
            float nearDistance = Mathf.Infinity;
            foreach (Collider colTarget in t_cols)
            {
                float distance = Vector3.SqrMagnitude(transform.position - colTarget.transform.position);

                if (nearDistance > distance)
                {
                    nearDistance = distance;
                    nearTarget = colTarget.transform;
                }
            }
        }
        target = nearTarget;
    }

    private void OnTriggerEnter(Collider other)
    {

    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(transform.position, unitAtkRange);
    //}
}
