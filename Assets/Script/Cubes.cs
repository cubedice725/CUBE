using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    // 할당은 Cube XPYPZP를 Cube[0,0]시작으로
    // Cube XMYMZM를 Cube[2,8]마지막으로 할당
    private Transform[,] Cube = new Transform[3,9];
    float T = 0;
    void Start()
    {
        Cube[0,0] = GameObject.Find("Cube XPYPZP").GetComponent<Transform>();
        Cube[0,1] = GameObject.Find("Cube YPZP").GetComponent<Transform>();
        Cube[0,2] = GameObject.Find("Cube XMYPZP").GetComponent<Transform>();
        Cube[0,3] = GameObject.Find("Cube XPYP").GetComponent<Transform>();
        Cube[0,4] = GameObject.Find("Cube YP").GetComponent<Transform>();
        Cube[0,5] = GameObject.Find("Cube XMYP").GetComponent<Transform>();
        Cube[0,6] = GameObject.Find("Cube XPYPZM").GetComponent<Transform>();
        Cube[0,7] = GameObject.Find("Cube YPZM").GetComponent<Transform>();
        Cube[0,8] = GameObject.Find("Cube XMYPZM").GetComponent<Transform>();

        Cube[1,0] = GameObject.Find("Cube XPZP").GetComponent<Transform>();
        Cube[1,1] = GameObject.Find("Cube ZP").GetComponent<Transform>();
        Cube[1,2] = GameObject.Find("Cube XMZP").GetComponent<Transform>();
        Cube[1,3] = GameObject.Find("Cube XP").GetComponent<Transform>();
        Cube[1,4] = GameObject.Find("Core Cube").GetComponent<Transform>();
        Cube[1,5] = GameObject.Find("Cube XM").GetComponent<Transform>();
        Cube[1,6] = GameObject.Find("Cube XPZM").GetComponent<Transform>();
        Cube[1,7] = GameObject.Find("Cube ZM").GetComponent<Transform>();
        Cube[1,8] = GameObject.Find("Cube XMZM").GetComponent<Transform>();

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

    void Update()
    {
        rotate();
    }
    public void rotate(){
        T += Time.deltaTime *100;
        Cube[0,0].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (T + 45)) * Mathf.Sqrt(2), 1, Mathf.Sin(Mathf.Deg2Rad * (T+45)) * Mathf.Sqrt(2));
        Cube[0,1].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (T + 90)), 1, Mathf.Sin(Mathf.Deg2Rad * (T+90)));
        Cube[0,2].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (T + 135)) * Mathf.Sqrt(2), 1, Mathf.Sin(Mathf.Deg2Rad * (T+135)) * Mathf.Sqrt(2));
        Cube[0,3].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (T + 180)), 1, Mathf.Sin(Mathf.Deg2Rad * (T+180)));

        Cube[0,5].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (T + 225)) * Mathf.Sqrt(2), 1, Mathf.Sin(Mathf.Deg2Rad * (T+225)) * Mathf.Sqrt(2));
        Cube[0,6].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (T + 270)), 1, Mathf.Sin(Mathf.Deg2Rad * (T+270)));
        Cube[0,7].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (T + 315)) * Mathf.Sqrt(2), 1, Mathf.Sin(Mathf.Deg2Rad * (T+315)) * Mathf.Sqrt(2));
        Cube[0,8].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (T + 0)), 1, Mathf.Sin(Mathf.Deg2Rad * (T+0)));

    }
}
