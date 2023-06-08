using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    static public Player instance;

    public Transform _towerPos;
    public GameManager gmCs;
    public UIManager uiManager;
    public Ground _ground;
    public GameObject _buildListUI;
    public RaycastHit hit;
    public Transform normalTower;
    public Transform _gndTr; // 설치할 땅의 오브젝트 위치
    public bool isCanbuild; // 설치 가능 여부 확인
    public int towerIndex;
    Ray ray;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        
        if (Physics.Raycast(ray, out hit))
        {
            if (gmCs.isBuilding)    // 유저가 타워 버튼을 클릭했을 때
            {
                //normalTower.position = Vector3.MoveTowards(new Vector3(normalTower.position.x, 0, normalTower.position.z), new Vector3(hit.point.x, 0, hit.point.z), 1f);
                normalTower.position = new Vector3(hit.point.x, 0, hit.point.z);
                // 타워 1을 클릭하고 나서 2를 클릭하면 비활성화되게
            }
            

            if (Input.GetMouseButtonDown(0) && _gndTr !=null && isCanbuild)
            {
                BuildTower(towerIndex);
            }
            //BuildTower(hit);
        }
    }

    void BuildTower(int towerIndex)   // 타워 만드는 함수
    {
        GameObject tower = Instantiate(gmCs._gmBuildList[towerIndex], _gndTr.position + new Vector3(0, 0.4f, 0), Quaternion.identity);
        tower.name = $"궁수({towerIndex+1}단계)";
        tower.SetActive(true);
        Renderer[] rend = tower.GetComponentsInChildren<Renderer>();

        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].material.color = new Color(rend[i].material.color.r, rend[i].material.color.g, rend[i].material.color.b, 1f);
        }

        switch (towerIndex)
        {
            case 0:
                ArchorTower1 archorTower1 = tower.GetComponent<ArchorTower1>();
                archorTower1._isCanAtk = true;
                GameManager.instance._playerGold -= archorTower1.unitPrice;
                UIManager.instance._playerGoldTxt.text = $"골드 보유량 : {GameManager.instance._playerGold} Gold";
                break;

            case 1:
                ArchorTower2 archorTower2 = tower.GetComponent<ArchorTower2>();
                archorTower2._isCanAtk = true;
                GameManager.instance._playerGold -= archorTower2.unitPrice;
                UIManager.instance._playerGoldTxt.text = $"골드 보유량 : {GameManager.instance._playerGold} Gold";
                break;

            case 2:
                ArchorTower3 archorTower3 = tower.GetComponent<ArchorTower3>();
                archorTower3._isCanAtk = true;
                GameManager.instance._playerGold -= archorTower3.unitPrice;
                UIManager.instance._playerGoldTxt.text = $"골드 보유량 : {GameManager.instance._playerGold} Gold";
                break;

        }
        
        gmCs._gmBuildList[towerIndex].SetActive(false);
        gmCs.isBuilding = false;

        uiManager.StartCoroutine(uiManager.BuildTowerPopUp());
    }


    

}
