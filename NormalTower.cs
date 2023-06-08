using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalTower : MonoBehaviour
{
    [SerializeField]
    List<Ground> grounds = new List<Ground>();

    [SerializeField]
    Camera mainCam;

    [SerializeField]
    Transform normalTower = null;

    [SerializeField]
    float tower_Range = 0f;

    [SerializeField]
    LayerMask layerMask = 0;

    Transform target = null;

    [SerializeField]
    Animator anim;
    [SerializeField]
    float atkDelay=0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SearchEnemy", 0f, 0.5f);
        anim = GetComponent<Animator>();

    }
    //private void OnEnable()
    //{
    //    //for (int i = 0; i < grounds.Count; i++)
    //    //{
    //    //    grounds[i].isWorking = false;
    //    //    print(grounds[i].isWorking);
    //    //}

    //    //grounds.Clear();

    //    //
    //    //

    //}
    // Update is called once per frame
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
        //transform.position = Vector3.MoveTowards(transform.position, Input.mousePosition, 1f);
        //if (gameObject.activeSelf==false)
        //{
        //    for (int i = 0; i < grounds.Count; i++)
        //    {
        //        grounds[i].isWorking = false;
        //    }
        //    grounds.Clear();
        //}

        if (atkDelay<=2)
        {
            atkDelay += 0.1f;
        }
        if (target==null)
        {
            anim.SetBool("isAtk", false);
        }
        else if (target!=null&& atkDelay>=2)
        {
            atkDelay = 0;
            Debug.Log("적 탐색 완료");
            Vector3 dir = target.transform.position - transform.position;


            Quaternion rot = Quaternion.LookRotation(dir.normalized);

            transform.rotation = rot;

            anim.SetBool("isAtk", true);
            
        }
    }
    void SearchEnemy()  //주변의 적을 탐지하는 함수
    {
        Collider[] t_cols = Physics.OverlapSphere(transform.position, tower_Range, layerMask);
        Transform nearTarget = null;

        if (t_cols.Length>0)
        {
            float nearDistance = Mathf.Infinity;
            foreach(Collider colTarget in t_cols)
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
        if (other.gameObject.layer == 6)
        {
            grounds.Add(other.gameObject.GetComponent<Ground>());

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 45f);
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    print("그라운드 온트리거 스테이");

    //    isWorking = false;

    //}
}
