using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeMove : MonoBehaviour{
    // 할당은 Cube XPYPZP를 Cube[0,0]시작으로
    // Cube XMYMZM를 Cube[2,8]마지막으로 할당
    private Transform[,] Cube = new Transform[3,9];

    private void Start() {
        Cube[0,0] = GameObject.Find("Cube XPYPZP").GetComponent<Transform>();
        Cube[0,1] = GameObject.Find("Cube XPYP").GetComponent<Transform>();
        Cube[0,2] = GameObject.Find("Cube XPYPZM").GetComponent<Transform>();
        Cube[0,3] = GameObject.Find("Cube YPZP").GetComponent<Transform>();
        Cube[0,4] = GameObject.Find("Cube YP").GetComponent<Transform>();
        Cube[0,5] = GameObject.Find("Cube YPZM").GetComponent<Transform>();
        Cube[0,6] = GameObject.Find("Cube XMYPZP").GetComponent<Transform>();
        Cube[0,7] = GameObject.Find("Cube YPZP").GetComponent<Transform>();
        Cube[0,8] = GameObject.Find("Cube XMYMZM").GetComponent<Transform>();

        Cube[1,0] = GameObject.Find("Cube XPZP").GetComponent<Transform>();
        Cube[1,1] = GameObject.Find("Cube XP").GetComponent<Transform>();
        Cube[1,2] = GameObject.Find("Cube XPZM").GetComponent<Transform>();
        Cube[1,3] = GameObject.Find("Cube ZP").GetComponent<Transform>();
        Cube[1,4] = GameObject.Find("Core Cube").GetComponent<Transform>();
        Cube[1,5] = GameObject.Find("Cube ZM").GetComponent<Transform>();
        Cube[1,6] = GameObject.Find("Cube XPZP").GetComponent<Transform>();
        Cube[1,7] = GameObject.Find("Cube XPZP").GetComponent<Transform>();
        Cube[1,8] = GameObject.Find("Cube XPZP").GetComponent<Transform>();

        Cube[2,0] = GameObject.Find("Cube XPYMZP").GetComponent<Transform>();
        Cube[2,1] = GameObject.Find("Cube YMZP").GetComponent<Transform>();
        Cube[2,2] = GameObject.Find("Cube XMYMZP").GetComponent<Transform>();
        Cube[2,3] = GameObject.Find("Cube XPYM").GetComponent<Transform>();
        Cube[2,4] = GameObject.Find("Cube YM").GetComponent<Transform>();
        Cube[2,5] = GameObject.Find("Cube XMYM").GetComponent<Transform>();
        Cube[2,6] = GameObject.Find("Cube XPYMZM").GetComponent<Transform>();
        Cube[2,7] = GameObject.Find("Cube YMZM").GetComponent<Transform>();
        Cube[2,8] = GameObject.Find("Cube XMYMZM").GetComponent<Transform>();
    }
}
