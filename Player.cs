using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public Transform _towerPos;
    public GameManager gmCs;
    public UIManager uiManager;
    public Ground _ground;
    public GameObject _buildListUI;
    public RaycastHit hit;
    public Transform normalTower;
    public Transform _gndTr; // 설치할 땅의 오브젝트 위치
    public bool isCanbuild; // 설치 가능 여부 확인
    Ray ray;

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
                normalTower.position = Vector3.MoveTowards(new Vector3(normalTower.position.x, 0, normalTower.position.z), new Vector3(hit.point.x, 0, hit.point.z), 1f);
            }
            

            if (Input.GetMouseButtonDown(0) && isCanbuild)
            {
                GameObject normalTower = Instantiate(gmCs._gMbuildList[0], _gndTr.position + new Vector3(0, 0.4f, 0), Quaternion.identity);
                normalTower.name = "궁수(1단계)";
                normalTower.SetActive(true);
                Renderer[] rend = normalTower.GetComponentsInChildren<Renderer>();
                for (int i = 0; i < rend.Length; i++)
                {
                    rend[i].material.color = new Color(rend[i].material.color.r, rend[i].material.color.g, rend[i].material.color.b, 1f);
                }
                gmCs._gMbuildList[0].SetActive(false);
                gmCs.isBuilding = false;
                //uiManager.isPopUpShow = false;
                
                uiManager.StartCoroutine(uiManager.BuildTowerPopUp());
            }
            //BuildTower(hit);
        }
    }

    void BuildTower(RaycastHit hit)   // 타워 만드는 함수
    {
        switch (hit.transform.tag)
        {
            case "possBuild":
                _ground = hit.transform.gameObject.GetComponent<Ground>();
                _towerPos= _ground.transform;   //타워 설치할 땅의 위치 전달
                _buildListUI.SetActive(true);  // 타워 리스트 이미지 오브젝트 활성화
                
                break;
            case "imPossBuild":
                _ground = hit.transform.gameObject.GetComponent<Ground>();
                _buildListUI.SetActive(false);  // 타워 리스트 이미지 오브젝트 비활성화
                break;
            default:
                break;
        }
    }

    

}
