using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    public GameObject[] _gmMonsterList;   // 몬스터리스트

    public GameObject[] objectFolling;

    public GameObject[] _gmBuildList;   // 플레이어 타워 리스트
    

    public GameObject buildGrounds; //그라운드 오브젝트들

    public bool isBuilding; // 플레이어가 설치하는지 확인하는 bool 자료형

    public Transform[] stg1WayPoints;   // Stage1의 웨이포인트 배열

    public int _playerGold; //플레이어 골드량
    public bool _isEarnGold; // 플레이어가 골드 획득 가능할 때 true 로 바뀌는 자료형
    float time;
    public bool isWaveStart;    //웨이브 시작했는지 확인하는 함수
    public int wave;
    public int waveStartMonsterCnt;
    public int waveMonsterCnt;

    [SerializeField]
    Transform spawnPoint;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else if (instance!=this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        _playerGold = 1250; // 플레이어에게 기본 골드량 부여

        for (int i = 0; i < 30; i++)
        {
            print(_gmMonsterList[0]);
            GameObject Monster = Instantiate(_gmMonsterList[0]);
            Monster.SetActive(false);
            objectFolling[i]=Monster;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isBuilding)
        {
            buildGrounds.SetActive(true);
        }
        else if(!isBuilding)
        {
            buildGrounds.SetActive(false);
        }
        if (time < 1)
        {
            time += Time.deltaTime;
            _isEarnGold = false;
        }
        else if(time >=1)
        {
            _playerGold += 1;
            _isEarnGold = true;
            time = 0;
        }
        if (isWaveStart&&(waveStartMonsterCnt==waveMonsterCnt))
        {
            wave++;
            
            isWaveStart = false;
            
        }
        if (wave == 6)
        {
            UIManager.instance.clearPopUpGm.SetActive(true);
        }
    }

    public IEnumerator SpawnMonster()
    {
        isWaveStart = true;
        switch (wave)
        {
            case 1:

                waveMonsterCnt = 0;
                waveStartMonsterCnt = 5;
                for (int i = 0; i < 5; i++)
                {
                    objectFolling[i].transform.position = spawnPoint.position;
                    objectFolling[i].SetActive(true);
                    yield return new WaitForSeconds(1);
                }
                
                break;

            case 2:
                waveMonsterCnt = 0;
                waveStartMonsterCnt = 9;
                for (int i = 0; i < 9; i++)
                {
                    objectFolling[i].transform.position = spawnPoint.position;
                    objectFolling[i].SetActive(true);
                    yield return new WaitForSeconds(1);
                }
                
                break;

            case 3:
                waveMonsterCnt = 0;
                waveStartMonsterCnt = 15;
                for (int i = 0; i < 15; i++)
                {
                    objectFolling[i].transform.position = spawnPoint.position;
                    objectFolling[i].SetActive(true);
                    yield return new WaitForSeconds(1);
                }
                break;
            case 4:
                waveMonsterCnt = 0;
                waveStartMonsterCnt = 20;
                for (int i = 0; i < 20; i++)
                {
                    objectFolling[i].transform.position = spawnPoint.position;
                    objectFolling[i].SetActive(true);
                    yield return new WaitForSeconds(1);
                }
                break;
            case 5:
                waveMonsterCnt = 0;
                waveStartMonsterCnt = 30;
                for (int i = 0; i < 30; i++)
                {
                    objectFolling[i].transform.position = spawnPoint.position;
                    objectFolling[i].SetActive(true);
                    yield return new WaitForSeconds(1);
                }
                break;
        }
    }
}
