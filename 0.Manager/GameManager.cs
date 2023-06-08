using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] _gMbuildList;
    public GameObject buildGrounds;
    public bool isBuilding;
    public Transform[] stg1WayPoints;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isBuilding)
        {
            buildGrounds.SetActive(true);
        }
        else if(!isBuilding)
        {
            buildGrounds.SetActive(false);
        }
    }
}
