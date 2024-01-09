using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour{
    private Transform[,] Cube = new Transform[3, 9];
    float angle = 0;
    int speed = 100;
    void Start(){
        // 큐브 윗 부분       큐브 옆부분
        // [2,3] [2,2] [2,1] [2,3] [2,4] [2,5]
        // [2,4] [2,8] [2,0] [1,3] [1,4] [1,5]
        // [2,5] [2,6] [2,7] [0,3] [0,4] [0,5]
        Cube[2, 0] = GameObject.Find("Cube XPYP").GetComponent<Transform>();
        Cube[2, 1] = GameObject.Find("Cube XPYPZP").GetComponent<Transform>();
        Cube[2, 2] = GameObject.Find("Cube YPZP").GetComponent<Transform>();
        Cube[2, 3] = GameObject.Find("Cube XMYPZP").GetComponent<Transform>();
        Cube[2, 4] = GameObject.Find("Cube XMYP").GetComponent<Transform>();
        Cube[2, 5] = GameObject.Find("Cube XMYPZM").GetComponent<Transform>();
        Cube[2, 6] = GameObject.Find("Cube YPZM").GetComponent<Transform>();
        Cube[2, 7] = GameObject.Find("Cube XPYPZM").GetComponent<Transform>();
        Cube[2, 8] = GameObject.Find("Cube YP").GetComponent<Transform>();

        Cube[1, 0] = GameObject.Find("Cube XP").GetComponent<Transform>();
        Cube[1, 1] = GameObject.Find("Cube XPZP").GetComponent<Transform>();
        Cube[1, 2] = GameObject.Find("Cube ZP").GetComponent<Transform>();
        Cube[1, 3] = GameObject.Find("Cube XMZP").GetComponent<Transform>();
        Cube[1, 4] = GameObject.Find("Cube XM").GetComponent<Transform>();
        Cube[1, 5] = GameObject.Find("Cube XMZM").GetComponent<Transform>();
        Cube[1, 6] = GameObject.Find("Cube ZM").GetComponent<Transform>();
        Cube[1, 7] = GameObject.Find("Cube XPZM").GetComponent<Transform>();
        Cube[1, 8] = GameObject.Find("Core Cube").GetComponent<Transform>();

        Cube[0, 0] = GameObject.Find("Cube XPYM").GetComponent<Transform>();
        Cube[0, 1] = GameObject.Find("Cube XPYMZP").GetComponent<Transform>();
        Cube[0, 2] = GameObject.Find("Cube YMZP").GetComponent<Transform>();
        Cube[0, 3] = GameObject.Find("Cube XMYMZP").GetComponent<Transform>();
        Cube[0, 4] = GameObject.Find("Cube XMYM").GetComponent<Transform>();
        Cube[0, 5] = GameObject.Find("Cube XMYMZM").GetComponent<Transform>();
        Cube[0, 6] = GameObject.Find("Cube YMZM").GetComponent<Transform>();
        Cube[0, 7] = GameObject.Find("Cube XPYMZM").GetComponent<Transform>();
        Cube[0, 8] = GameObject.Find("Cube YM").GetComponent<Transform>();
    }

    void Update(){
        HorizontalRotate(2);
    }
    public void HorizontalRotate(int floor){
        angle += Time.deltaTime * speed;
        for (int i = 0; i < 8; i++)
        {
            if(i % 2 == 0){
                Cube[floor, i].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + i * 45)), floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + i * 45)));
                Cube[floor, i].transform.rotation = Quaternion.Euler(0, -angle, 0);
            }else{
                Cube[floor, i].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + i *45)) * Mathf.Sqrt(2), floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + i*45)) * Mathf.Sqrt(2));
                Cube[floor, i].transform.rotation = Quaternion.Euler(0, -angle, 0);
            }
        }
        Cube[floor, 8].transform.rotation = Quaternion.Euler(0, -angle, 0);
    }
    public void Vertical(int floor){
        angle += Time.deltaTime * speed;
        for (int i = 0; i < 8; i++)
        {
            if(i % 2 == 0){
                Cube[floor, i].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + i * 45)), floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + i * 45)));
                Cube[floor, i].transform.rotation = Quaternion.Euler(0, -angle, 0);
            }else{
                Cube[floor, i].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + i *45)) * Mathf.Sqrt(2), floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + i*45)) * Mathf.Sqrt(2));
                Cube[floor, i].transform.rotation = Quaternion.Euler(0, -angle, 0);
            }
        }
        Cube[floor, 8].transform.rotation = Quaternion.Euler(0, -angle, 0);
    }
}
