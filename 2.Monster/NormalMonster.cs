using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NormalMonster : MonsterBase
{

    [SerializeField]
    Transform target;

    Rigidbody rb;
    [SerializeField]
    int wavePointIndex=0;
    [SerializeField]
    Image hpBar;
    bool isTurning; // 웨이포인트 지점에서 턴하는지 확인하는 자료형

    bool isAtking; // 넥서스를 공격하는지 확인하는 자료형

    Animator anim;
    Transform spawnPoint;

    float time;
    GameObject castle;
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        
        wayPoints = GameManager.instance.stg1WayPoints;
        for (int i = 0; i < GameManager.instance.stg1WayPoints.Length; i++)
        {
            wayPoints[i] = GameManager.instance.stg1WayPoints[i];
        }
        target = wayPoints[0];
        monsterName = "노말몬스터";
        wavePointIndex = 0;
        startMonsterHp = 50;
        monsterHp = startMonsterHp;
        monsterAtkDmg = 1;
        monsterSpd = 3;
        isTurning = true;
        hpBar.fillAmount = (float)monsterHp / (float)startMonsterHp;
        isAtking = false;
        anim = GetComponent<Animator>();
        anim.SetBool("isRun", isTurning);
        time = 0;
    }
    void Start()
    {
        print(GameManager.instance.stg1WayPoints.Length);
        wayPoints = GameManager.instance.stg1WayPoints;
        for (int i = 0; i < GameManager.instance.stg1WayPoints.Length; i++)
        {
            wayPoints[i] = GameManager.instance.stg1WayPoints[i];
        }
        target = wayPoints[0];
        monsterName = "노말몬스터";
        startMonsterHp = 50;
        monsterHp = startMonsterHp;
        monsterAtkDmg = 1;
        monsterSpd = 3;
        isTurning=true;
        
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= 3f)
        {
            print("위치가 가까워졌음");
            GetNextWayPoint();
        }

        if (monsterHp<=0)
        {
            GameManager.instance._playerGold += 5;
            UIManager.instance._playerGoldTxt.text = $"골드 보유량 : {GameManager.instance._playerGold} Gold";
            GameManager.instance.waveMonsterCnt++;
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        
        if (isTurning)
        {
            Vector3 dir = target.transform.position - transform.position;


            Quaternion rot = Quaternion.LookRotation(dir.normalized);

            transform.rotation = rot;

            rb.velocity = transform.forward * 14;
        }

        if (isAtking)
        {
            rb.velocity = Vector3.zero;
            time += Time.deltaTime;
        }

        if (time>=3&&castle!=null&&isAtking)
        {
            Vector3 dir = castle.transform.position - transform.position;


            Quaternion rot = Quaternion.LookRotation(dir.normalized);

            transform.rotation = rot;

            anim.SetTrigger("trgAtk");

            castle.SendMessage("CastleGetDamaged", monsterAtkDmg);
            time = 0;
        }
        //if (wavePointIndex == 5 && Vector3.Distance(transform.position, wayPoints[5].position)<)
        //{

        //}
    }
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void GetNextWayPoint()  // 다음 포인트 지점을 알려주는 함수
    {
        if (wayPoints.Length >= wavePointIndex + 2)
        {
            rb.velocity = Vector3.zero;
            isTurning = false;
            wavePointIndex++;
            target = wayPoints[wavePointIndex];

            
            isTurning = true;
            //transform.LookAt(target);
            //nav.velocity = Vector3.zero;
            //nav.SetDestination(target.position);

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Castle")
        {
            
            isAtking = true;
            isTurning = false;
            anim.SetBool("isRun", isTurning);
            castle = other.gameObject;
            
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Castle")
        {
            
            isTurning = true;
            anim.SetBool("isRun", isTurning);
            isAtking = false;
        }
    }
    public override void GetDamaged(int atkDmg)    // 몬스터가 공격받았을 때 호출되는 함수
    {
        monsterHp -= atkDmg;
        hpBar.fillAmount = (float)monsterHp / (float)startMonsterHp;
        Debug.LogWarning($"몬스터 피해입음!, monsterHp :{monsterHp}");
    }
}
