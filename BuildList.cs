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
    //public void OnPointerEnter(PointerEventData eventData)  // ���콺�� UI ���� ���� ��
    //{
        
    //    switch(gameObject.name) // ���� ������Ʈ �̸��� �������� ��ġ�� Ÿ�� ������
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

    //public void OnPointerExit(PointerEventData eventData)   // ���콺�� UI ������ ���� ��
    //{
    //    if (gameObject.name == "Normal TowerBtn")
    //    {
    //        for (int i = 0; i < grounds.Length; i++)    // �׶��� ������Ʈ ����Ʈ�� ������ŭ �ݺ�
    //        {
    //            grounds[i].isWorking = false;
    //        }
    //        print(gmSc._gMbuildList[0]);
    //        gmSc._gMbuildList[0].SetActive(false);  //���ÿ� ����ȭ�� �Ϲ�Ÿ�� �ٽ� ��Ȱ��ȭ
    //    }
    //}
    //public void ClickNormalTower()  //�Ϲ� Ÿ�� ��ġ�ϴ� �Լ�
    //{
    //    print(gameObject.name);
    //    GameObject normalTower=Instantiate(gmSc._gMbuildList[0], playerSc._towerPos.position + new Vector3(0, 0.4f, 0), Quaternion.identity);
    //    normalTower.SetActive(true);
    //    Renderer[] rend =normalTower.GetComponentsInChildren<Renderer>();
    //    for (int i = 0; i < rend.Length; i++)
    //    {
    //        rend[i].material.color = new Color(rend[i].material.color.r, rend[i].material.color.g, rend[i].material.color.b, 1f);
    //    }
    //    for (int i = 0; i < grounds.Length; i++)    // �׶��� ������Ʈ ����Ʈ�� ������ŭ �ݺ�
    //    {
    //        grounds[i].isWorking = false;
    //    }
    //    //playerSc._buildListUI.SetActive(false);
    //    playerSc._ground._possibleSign.SetActive(false);
    //    playerSc._ground.gameObject.tag = "imPossBuild";
    //}
}
