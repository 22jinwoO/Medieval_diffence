using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField]
    Image towerBuildImg;    // �÷��̾ Ÿ���� ��ġ�� �� Ȱ��ȭ �Ǵ� �˾�â
    [SerializeField]
    RectTransform towerBuildPopUpRtr;

    [SerializeField]
    Button slideBtn;

    [SerializeField]
    Button archorTower1Btn;  // �ü� 1�ܰ� ��ư
    [SerializeField]
    Button archorTower2Btn;  // �ü� 2�ܰ� ��ư

    [SerializeField]
    Button archorTower3Btn;  // �ü� 3�ܰ� ��ư
    public bool isPopUpShow = true;  // �˾�â�� ���� �������� �����ϴ� ����

    [SerializeField]
    Player playerCs;

    [SerializeField]
    GameManager gmCs;

    public Text _playerGoldTxt; //�÷��̾� ��� ������ �����ִ� �ؽ�Ʈ

    [SerializeField]
    Button settingBtn;

    [SerializeField]
    Button WaveStartBtn;

    [SerializeField]
    Text showWaveTxt;

    public GameObject clearPopUpGm;

    [SerializeField]
    Button goHomeBtn;

    [SerializeField]
    Button wavePassBtn;

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


        slideBtn.onClick.AddListener(() => StartCoroutine(BuildTowerPopUp()));
        archorTower1Btn.onClick.AddListener(ClickArchorTower1Btn);
        archorTower2Btn.onClick.AddListener(ClickArchorTower2Btn);
        archorTower3Btn.onClick.AddListener(ClickArchorTower3Btn);
        gmCs = GameManager.instance;
        settingBtn.onClick.AddListener(ClickGoHome);
        goHomeBtn.onClick.AddListener(ClickGoHome);
        WaveStartBtn.onClick.AddListener(() => GameManager.instance.StartCoroutine("SpawnMonster"));
        wavePassBtn.onClick.AddListener(ClickWavePass);
    }

    void Update()
    {
        if (GameManager.instance._isEarnGold)
        {
            _playerGoldTxt.text = $"��� ������ : {GameManager.instance._playerGold} Gold";
        }

        if (GameManager.instance._playerGold < 50)
        {
            archorTower1Btn.interactable = false;
        }
        else if (GameManager.instance._playerGold >= 50)
        {
            archorTower1Btn.interactable = true;
        }

        if (GameManager.instance._playerGold < 200)
        {
            archorTower2Btn.interactable = false;
        }
        else if (GameManager.instance._playerGold >= 200)
        {
            archorTower2Btn.interactable = true;
        }

        if (GameManager.instance._playerGold < 1000)
        {
            archorTower3Btn.interactable = false;
        }
        else if (GameManager.instance._playerGold >= 1000)
        {
            archorTower3Btn.interactable = true;
        }
        if (!GameManager.instance.isWaveStart)
        {
            showWaveTxt.text = $"Wave 1-{GameManager.instance.wave}";
            WaveStartBtn.gameObject.SetActive(true);
            wavePassBtn.gameObject.SetActive(true);
        }
        else if (GameManager.instance.isWaveStart)
        {
            WaveStartBtn.gameObject.SetActive(false);
            wavePassBtn.gameObject.SetActive(false);
        }
    }
    #region # BuildTowerPopUp() : Ÿ�� ���� ����Ʈâ Ȱ��ȭ �ϴ� �Լ�
    public IEnumerator BuildTowerPopUp()    //Ÿ�� ���帮��Ʈ â Ȱ��ȭ �ϴ� �Լ�
    {
        if (gmCs._gmBuildList[0].activeSelf == true || gmCs._gmBuildList[1].activeSelf == true || gmCs._gmBuildList[2].activeSelf == true)
        {
            gmCs._gmBuildList[0].SetActive(false);
            gmCs._gmBuildList[1].SetActive(false);
            gmCs._gmBuildList[2].SetActive(false);
        }
        print("Ÿ�� ����â �˾� Ȱ��ȭ");
        float time = 0;
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

    public void ClickArchorTower1Btn()  // �ü� 1�ܰ� ��ư Ŭ������ ��
    {
        if (gmCs._gmBuildList[1].activeSelf == true || gmCs._gmBuildList[2].activeSelf == true)
        {
            gmCs._gmBuildList[1].SetActive(false);
            gmCs._gmBuildList[2].SetActive(false);
        }
        archorTower1Btn.interactable = true;
        playerCs.towerIndex = 0;
        gmCs._gmBuildList[0].SetActive(true);
        playerCs.normalTower = gmCs._gmBuildList[0].transform;
        gmCs.isBuilding = true;
        //gmCs._gmBuildList[0].transform.position = Input.mousePosition;
    }

    public void ClickArchorTower2Btn()
    {
        if (gmCs._gmBuildList[0].activeSelf == true || gmCs._gmBuildList[2].activeSelf == true)
        {
            gmCs._gmBuildList[0].SetActive(false);
            gmCs._gmBuildList[2].SetActive(false);
        }
        print("�ü� 2�ܰ� ��ư Ŭ������");
        playerCs.towerIndex = 1;
        gmCs._gmBuildList[1].SetActive(true);
        playerCs.normalTower = gmCs._gmBuildList[1].transform;
        gmCs.isBuilding = true;
        //gmCs._gmBuildList[0].transform.position = Input.mousePosition;
    }

    public void ClickArchorTower3Btn()
    {
        if (gmCs._gmBuildList[0].activeSelf == true || gmCs._gmBuildList[1].activeSelf == true)
        {
            gmCs._gmBuildList[0].SetActive(false);
            gmCs._gmBuildList[1].SetActive(false);
        }
        print("�ü� 3�ܰ� ��ư Ŭ������");
        playerCs.towerIndex = 2;
        gmCs._gmBuildList[2].SetActive(true);
        playerCs.normalTower = gmCs._gmBuildList[2].transform;
        gmCs.isBuilding = true;
        //gmCs._gmBuildList[0].transform.position = Input.mousePosition;
    }
    void ClickWavePass()
    {
        GameManager.instance.wave += 1;
    }
    void ClickGoHome()
    {
        SceneManager.LoadScene("StartScene");
    }
}
