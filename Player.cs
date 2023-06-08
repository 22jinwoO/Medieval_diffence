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

    void BuildTower(RaycastHit hit)   // Ÿ�� ����� �Լ�
    {
        switch (hit.transform.tag)
        {
            case "possBuild":
                _ground = hit.transform.gameObject.GetComponent<Ground>();
                _towerPos= _ground.transform;   //Ÿ�� ��ġ�� ���� ��ġ ����
                _buildListUI.SetActive(true);  // Ÿ�� ����Ʈ �̹��� ������Ʈ Ȱ��ȭ
                
                break;
            case "imPossBuild":
                _ground = hit.transform.gameObject.GetComponent<Ground>();
                _buildListUI.SetActive(false);  // Ÿ�� ����Ʈ �̹��� ������Ʈ ��Ȱ��ȭ
                break;
            default:
                break;
        }
    }

    

}
