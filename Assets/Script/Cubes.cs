using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    private Transform Cube_XP;
    void Start()
    {
        Cube_XP = GameObject.Find("Cube XP").GetComponent<Transform>();
        Cube_XP.transform.Translate(2,0,0);
    }

    void Update()
    {
        
    }
}
