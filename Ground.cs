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
        //        _possibleSign.SetActive(true);  // 설치 가능 영역 오브젝트 활성화
        //        imPossibleSign.SetActive(false);    // 설치 불가능 영역 오브젝트 비활성화
        //    }
        //    else if (gameObject.tag == "imPossBuild")
        //    {
        //        imPossibleSign.SetActive(true); // 설치 불가능 영역 오브젝트 활성화
        //        _possibleSign.SetActive(false); // 설치 가능 영역 오브젝트 비활성화
        //    }

        //}

        //if (!isWorking && (_possibleSign.activeSelf == true || imPossibleSign.activeSelf == true))
        //{
        //    print("그라운드 설치가능");
        //    _possibleSign.SetActive(false); // 설치 가능 영역 오브젝트 비활성화
        //    imPossibleSign.SetActive(false);    // 설치 불가능 영역 오브젝트 비활성화
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="inStallRange")
        {
            print("궁수와 충돌함");
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
            print("궁수와 충돌끝");
            isCollision = false;
            playerCs._gndTr = null;
        }
    }
}
