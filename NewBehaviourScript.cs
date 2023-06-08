using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    List<Ground> grounds = new List<Ground> ();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer==6)
        {
            grounds.Add(collision.gameObject.GetComponent<Ground>());
                
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer==6)
        {
            print(1234451);
            collision.transform.GetComponent<Ground>().isWorking = false;
        }
    }
}
