using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ground : MonoBehaviour
{
    public bool isWorking;
    //public Transform emptyPos;
    
    public GameObject _possibleSign;
    [SerializeField]
    GameObject imPossibleSign;

    private void Start()
    {
        
    }
    private void Update()
    {
        print(_possibleSign.name);
        if (isWorking)
        {
            if (gameObject.tag == "possBuild")
            {
                _possibleSign.SetActive(true);  // ��ġ ���� ���� ������Ʈ Ȱ��ȭ
                imPossibleSign.SetActive(false);    // ��ġ �Ұ��� ���� ������Ʈ ��Ȱ��ȭ
            }
            else if (gameObject.tag == "imPossBuild")
            {
                imPossibleSign.SetActive(true); // ��ġ �Ұ��� ���� ������Ʈ Ȱ��ȭ
                _possibleSign.SetActive(false); // ��ġ ���� ���� ������Ʈ ��Ȱ��ȭ
            }

        }

        if (!isWorking && (_possibleSign.activeSelf == true || imPossibleSign.activeSelf == true))
        {
            print("�׶��� ��ġ����");
            _possibleSign.SetActive(false); // ��ġ ���� ���� ������Ʈ ��Ȱ��ȭ
            imPossibleSign.SetActive(false);    // ��ġ �Ұ��� ���� ������Ʈ ��Ȱ��ȭ
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="inStallRange")
        {
            isWorking = true;
        }
    }
    
}
