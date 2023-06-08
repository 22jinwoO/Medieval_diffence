using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTower : MonoBehaviour
{
    Renderer rend;
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();

        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0.3f);
    }

    void Update()
    {
        
    }
}
