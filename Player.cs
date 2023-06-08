using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public Transform _towerPos;
    public Ground _ground;
    public GameObject _buildListUI;
    public RaycastHit hit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            

            if(Physics.Raycast(ray, out hit))
            {
                BuildTower(hit);
            }
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
