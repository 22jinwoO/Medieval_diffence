using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildList : MonoBehaviour/*, IPointerEnterHandler, IPointerExitHandler*/
{
    public Player playerSc;


    [SerializeField]
    public Transform emptyGmPos;

    void Start()
    {

    }

    void Update()
    {
        
    }
    
    void ClickNormalTowerBtn()
    {
        
    }
    //public void OnPointerEnter(PointerEventData eventData)  // 마우스가 UI 위에 있을 때
    //{
        
    //    switch(gameObject.name) // 게임 오브젝트 이름에 구분지어 설치할 타워 보여줌
    //    {
    //        case "Normal TowerBtn":
    //            gmSc._gMbuildList[0].SetActive(true);
    //            print(gmSc._gMbuildList[0].name);
    //            gmSc._gMbuildList[0].transform.position = playerSc._towerPos.position+new Vector3(0,0.4f,0);
    //            break;

    //        case "Skill TowerBtn":
    //            gmSc._gMbuildList[1].SetActive(true);
    //            print(gmSc._gMbuildList[1].name);
    //            gmSc._gMbuildList[1].transform.position = playerSc._towerPos.position+Vector3.up;
    //            break;
    //    }
    //}

    //public void OnPointerExit(PointerEventData eventData)   // 마우스가 UI 밖으로 나갈 때
    //{
    //    if (gameObject.name == "Normal TowerBtn")
    //    {
    //        for (int i = 0; i < grounds.Length; i++)    // 그라운드 오브젝트 리스트의 개수만큼 반복
    //        {
    //            grounds[i].isWorking = false;
    //        }
    //        print(gmSc._gMbuildList[0]);
    //        gmSc._gMbuildList[0].SetActive(false);  //예시용 투명화된 일반타워 다시 비활성화
    //    }
    //}
    //public void ClickNormalTower()  //일반 타워 설치하는 함수
    //{
    //    print(gameObject.name);
    //    GameObject normalTower=Instantiate(gmSc._gMbuildList[0], playerSc._towerPos.position + new Vector3(0, 0.4f, 0), Quaternion.identity);
    //    normalTower.SetActive(true);
    //    Renderer[] rend =normalTower.GetComponentsInChildren<Renderer>();
    //    for (int i = 0; i < rend.Length; i++)
    //    {
    //        rend[i].material.color = new Color(rend[i].material.color.r, rend[i].material.color.g, rend[i].material.color.b, 1f);
    //    }
    //    for (int i = 0; i < grounds.Length; i++)    // 그라운드 오브젝트 리스트의 개수만큼 반복
    //    {
    //        grounds[i].isWorking = false;
    //    }
    //    //playerSc._buildListUI.SetActive(false);
    //    playerSc._ground._possibleSign.SetActive(false);
    //    playerSc._ground.gameObject.tag = "imPossBuild";
    //}
}
