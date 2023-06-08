using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    public GameObject[] _gmMonsterList;   // ���͸���Ʈ

    public GameObject[] objectFolling;

    public GameObject[] _gmBuildList;   // �÷��̾� Ÿ�� ����Ʈ
    

    public GameObject buildGrounds; //�׶��� ������Ʈ��

    public bool isBuilding; // �÷��̾ ��ġ�ϴ��� Ȯ���ϴ� bool �ڷ���

    public Transform[] stg1WayPoints;   // Stage1�� ��������Ʈ �迭

    public int _playerGold; //�÷��̾� ��差
    public bool _isEarnGold; // �÷��̾ ��� ȹ�� ������ �� true �� �ٲ�� �ڷ���
    float time;
    public bool isWaveStart;    //���̺� �����ߴ��� Ȯ���ϴ� �Լ�
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
        _playerGold = 1250; // �÷��̾�� �⺻ ��差 �ο�

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
