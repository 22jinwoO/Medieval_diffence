using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Image towerBuildImg;    // �÷��̾ Ÿ���� ��ġ�� �� Ȱ��ȭ �Ǵ� �˾�â
    [SerializeField]
    RectTransform towerBuildPopUpRtr;

    [SerializeField]
    Button slideBtn;

    [SerializeField]
    Button normalTowerBtn;

    public bool isPopUpShow=true;  // �˾�â�� ���� �������� �����ϴ� ����

    [SerializeField]
    Player playerCs;

    [SerializeField]
    GameManager gmCs;

    void Start()
    {
        slideBtn.onClick.AddListener(()=>StartCoroutine(BuildTowerPopUp()));
        normalTowerBtn.onClick.AddListener(ClickNormalTowerBtn);
    }

    void Update()
    {

    }
    #region
    public IEnumerator BuildTowerPopUp()    //Ÿ�� ���帮��Ʈ â Ȱ��ȭ �ϴ� �Լ�
    {
        print("Ÿ�� ����â �˾� Ȱ��ȭ");
        float time=0;
        if (!isPopUpShow)
        {
            while (time < 1f)
            {
                slideBtn.interactable = false;
                towerBuildPopUpRtr.anchoredPosition = new Vector3(0, towerBuildPopUpRtr.anchoredPosition.y - 20, 0);
                time += 0.1f;
                yield return null;
            }
            isPopUpShow = true;
            slideBtn.interactable = true;
        }
        
        else if (isPopUpShow)
        {
            while (time < 1f)
            {
                slideBtn.interactable = false;
                print(towerBuildPopUpRtr.anchoredPosition);
                towerBuildPopUpRtr.anchoredPosition = new Vector3(0, towerBuildPopUpRtr.anchoredPosition.y + 20, 0);
                time += 0.1f;
                print(time);
                yield return null;
            }
            isPopUpShow = false;
            slideBtn.interactable = true;
        }
        
    }
    #endregion

    public void ClickNormalTowerBtn()
    {
        print("�븻Ÿ�� ����������");
        
        gmCs._gMbuildList[0].SetActive(true);
        playerCs.normalTower = gmCs._gMbuildList[0].transform;
        gmCs.isBuilding = true;
        //gmCs._gMbuildList[0].transform.position = Input.mousePosition;
    }
}
