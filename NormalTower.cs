using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTower : MonoBehaviour
{
    [SerializeField]
    List<Ground> grounds = new List<Ground>();

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            grounds[i].isWorking = false;
            print(grounds[i].isWorking);
        }
        
        grounds.Clear();
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf==false)
        {
            for (int i = 0; i < grounds.Count; i++)
            {
                grounds[i].isWorking = false;
            }
            grounds.Clear();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            grounds.Add(other.gameObject.GetComponent<Ground>());

        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    print("그라운드 온트리거 스테이");
 
    //    isWorking = false;

    //}
}
