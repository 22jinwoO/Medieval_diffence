using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ground : MonoBehaviour
{
    public Player playerCs;
    [SerializeField]
    Material[] outlines;
    public bool isWorking;
    [SerializeField]
    bool isCollision;

    //public Transform emptyPos;

    //public GameObject _possibleSign;

    //GameObject imPossibleSign;

    private void Start()
    {

        
    }
    private void Update()
    {

        if (isCollision)
        {
            gameObject.GetComponent<MeshRenderer>().material = outlines[2];
        }
        if (!isCollision)
        {
            gameObject.GetComponent<MeshRenderer>().material = outlines[0];
        }
        //print(_possibleSign.name);
        //if (isWorking)
        //{
        //    if (gameObject.tag == "possBuild")
        //    {
        //        _possibleSign.SetActive(true);  // ��ġ ���� ���� ������Ʈ Ȱ��ȭ
        //        imPossibleSign.SetActive(false);    // ��ġ �Ұ��� ���� ������Ʈ ��Ȱ��ȭ
        //    }
        //    else if (gameObject.tag == "imPossBuild")
        //    {
        //        imPossibleSign.SetActive(true); // ��ġ �Ұ��� ���� ������Ʈ Ȱ��ȭ
        //        _possibleSign.SetActive(false); // ��ġ ���� ���� ������Ʈ ��Ȱ��ȭ
        //    }

        //}

        //if (!isWorking && (_possibleSign.activeSelf == true || imPossibleSign.activeSelf == true))
        //{
        //    print("�׶��� ��ġ����");
        //    _possibleSign.SetActive(false); // ��ġ ���� ���� ������Ʈ ��Ȱ��ȭ
        //    imPossibleSign.SetActive(false);    // ��ġ �Ұ��� ���� ������Ʈ ��Ȱ��ȭ
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="inStallRange")
        {
            print("�ü��� �浹��");
            isCollision = true;
            if (!isWorking)
            {
                playerCs.isCanbuild=true;
                playerCs._gndTr = this.transform;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "inStallRange")
        {
            print("�ü��� �浹��");
            isCollision = false;
            playerCs._gndTr = null;
        }
    }
}
