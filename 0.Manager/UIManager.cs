using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Image towerBuildImg;    // 플레이어가 타워를 설치할 때 활성화 되는 팝업창
    [SerializeField]
    RectTransform towerBuildPopUpRtr;

    [SerializeField]
    Button slideBtn;

    [SerializeField]
    Button normalTowerBtn;

    public bool isPopUpShow=true;  // 팝업창을 위로 보여줄지 구분하는 변수

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
    public IEnumerator BuildTowerPopUp()    //타워 빌드리스트 창 활성화 하는 함수
    {
        print("타워 빌드창 팝업 활성화");
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
        print("노말타워 ㅋ르릭했음");
        
        gmCs._gMbuildList[0].SetActive(true);
        playerCs.normalTower = gmCs._gMbuildList[0].transform;
        gmCs.isBuilding = true;
        //gmCs._gMbuildList[0].transform.position = Input.mousePosition;
    }
}
