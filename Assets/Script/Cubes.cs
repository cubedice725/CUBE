using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    private Transform[,] Cube = new Transform[3, 9];
    float angle = 0;
    private RaycastHit hit;
    private Ray ray;
    private Vector3 V = new Vector3(0, 0, 0);

    int Speed = 10;
    int a, b, c;
    void Start()
    {
        // 큐브 Y부분         큐브 X부분        큐브 Z부분
        // [2,3] [2,2] [2,1] [2,7] [2,0] [2,1] [2,1] [2,2] [2,3] 
        // [2,4] [2,8] [2,0] [1,7] [1,0] [1,1] [1,1] [1,2] [1,3] 
        // [2,5] [2,6] [2,7] [0,7] [0,0] [0,1] [0,1] [0,2] [0,3] 
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

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Mouse();
        }
        if(Input.GetMouseButton(0)){
            RightMouseClick();
        }
    }

    public void RightMouseClick(){
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000f))
                Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 10f);
                Debug.Log(hit.point);
        }
    }
    public void Mouse()
    {
        transform.Rotate(0f, -Input.GetAxis("Mouse X") * Speed, 0f, Space.World);
        transform.Rotate(Input.GetAxis("Mouse Y") * Speed, 0f, 0f, Space.World);
    }

    public void Y_Rotate(int floor)
    {
        // 큐브 Y부분       
        // [2,3] [2,2] [2,1] 
        // [2,4] [2,8] [2,0] 
        // [2,5] [2,6] [2,7] 
        angle += Time.deltaTime * 100;
        var parentSyncY = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        for (int i = 0; i < 8; i++)
        {
            if (i % 2 == 0)
            {
                Cube[floor, i].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + i * 45)), floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + i * 45)));
                Cube[floor, i].transform.rotation = parentSyncY;
                Cube[floor, i].transform.Rotate(new Vector3(0, -angle, 0));

            }
            else
            {
                Cube[floor, i].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + i * 45)) * Mathf.Sqrt(2), floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + i * 45)) * Mathf.Sqrt(2));
                Cube[floor, i].transform.rotation = parentSyncY;
                Cube[floor, i].transform.Rotate(new Vector3(0, -angle, 0));

            }
        }
        Cube[floor, 8].transform.rotation = parentSyncY;
        Cube[floor, 8].transform.Rotate(new Vector3(0, -angle, 0));
    }
    public void X_Rotate(int floor)
    {
        // 큐브 X부분(2) X=1 | 큐브 X부분(1) X=0 | 큐브 X부분(1) X=-1
        // [2,7] [2,0] [2,1] | [2,6] [2,8] [2,2] | [2,5] [2,4] [2,3] 
        // [1,7] [1,0] [1,1] | [1,6] [1,8] [1,2] | [1,5] [1,4] [1,3] 
        // [0,7] [0,0] [0,1] | [0,6] [0,8] [0,2] | [0,5] [0,4] [0,3]
        angle += Time.deltaTime * 100;
        if (angle >= 360)
        {
            angle -= 360;
        }
        // Debug.Log();
        if (floor == 2)
        {
            a = 7; b = 0; c = 1;
        }
        else if (floor == 1)
        {
            a = 6; b = 8; c = 2;
        }
        else
        {
            a = 5; b = 4; c = 3;
        }
        var parentSyncX = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        Cube[1, c].transform.localPosition = new Vector3(floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + 0)), Mathf.Cos(Mathf.Deg2Rad * (angle + 0)));
        Cube[1, c].transform.rotation = parentSyncX;
        Cube[1, c].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[2, c].transform.localPosition = new Vector3(floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + 45)) * Mathf.Sqrt(2), Mathf.Cos(Mathf.Deg2Rad * (angle + 45)) * Mathf.Sqrt(2));
        Cube[2, c].transform.rotation = parentSyncX;
        Cube[2, c].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[2, b].transform.localPosition = new Vector3(floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + 90)), Mathf.Cos(Mathf.Deg2Rad * (angle + 90)));
        Cube[2, b].transform.rotation = parentSyncX;
        Cube[2, b].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[2, a].transform.localPosition = new Vector3(floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + 135)) * Mathf.Sqrt(2), Mathf.Cos(Mathf.Deg2Rad * (angle + 135)) * Mathf.Sqrt(2));
        Cube[2, a].transform.rotation = parentSyncX;
        Cube[2, a].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[1, a].transform.localPosition = new Vector3(floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + 180)), Mathf.Cos(Mathf.Deg2Rad * (angle + 180)));
        Cube[1, a].transform.rotation = parentSyncX;
        Cube[1, a].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[0, a].transform.localPosition = new Vector3(floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + 225)) * Mathf.Sqrt(2), Mathf.Cos(Mathf.Deg2Rad * (angle + 225)) * Mathf.Sqrt(2));
        Cube[0, a].transform.rotation = parentSyncX;
        Cube[0, a].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[0, b].transform.localPosition = new Vector3(floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + 270)), Mathf.Cos(Mathf.Deg2Rad * (angle + 270)));
        Cube[0, b].transform.rotation = parentSyncX;
        Cube[0, b].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[0, c].transform.localPosition = new Vector3(floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + 315)) * Mathf.Sqrt(2), Mathf.Cos(Mathf.Deg2Rad * (angle + 315)) * Mathf.Sqrt(2));
        Cube[0, c].transform.rotation = parentSyncX;
        Cube[0, c].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[1, b].transform.rotation = parentSyncX;
        Cube[1, b].transform.Rotate(new Vector3(-angle, 0, 0));
    }
    public void Z_Rotate(int floor)
    {
        // 큐브 Z부분(2) Z=1 | 큐브 Z부분(1) Z=0 | 큐브 Z부분(1) Z=-1
        // [2,3] [2,2] [2,1] | [2,4] [2,8] [2,0] | [2,5] [2,6] [2,7]
        // [1,3] [1,2] [1,1] | [1,4] [1,8] [1,0] | [1,5] [1,6] [1,7]
        // [0,3] [0,2] [0,1] | [0,4] [0,8] [0,0] | [0,5] [0,6] [0,7]
        angle += Time.deltaTime * 100;
        if (angle >= 360)
        {
            angle -= 360;
        }
        if (floor == 2)
        {
            a = 3; b = 2; c = 1;
        }
        else if (floor == 1)
        {
            a = 4; b = 8; c = 0;
        }
        else
        {
            a = 5; b = 6; c = 7;
        }
        var parentSyncZ = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        Cube[1, c].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 0)), Mathf.Sin(Mathf.Deg2Rad * (angle + 0)), floor - 1);
        Cube[1, c].transform.rotation = parentSyncZ;
        Cube[1, c].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[2, c].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 45)) * Mathf.Sqrt(2), Mathf.Sin(Mathf.Deg2Rad * (angle + 45)) * Mathf.Sqrt(2), floor - 1);
        Cube[2, c].transform.rotation = parentSyncZ;
        Cube[2, c].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[2, b].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 90)), Mathf.Sin(Mathf.Deg2Rad * (angle + 90)), floor - 1);
        Cube[2, b].transform.rotation = parentSyncZ;
        Cube[2, b].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[2, a].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 135)) * Mathf.Sqrt(2), Mathf.Sin(Mathf.Deg2Rad * (angle + 135)) * Mathf.Sqrt(2), floor - 1);
        Cube[2, a].transform.rotation = parentSyncZ;
        Cube[2, a].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[1, a].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 180)), Mathf.Sin(Mathf.Deg2Rad * (angle + 180)), floor - 1);
        Cube[1, a].transform.rotation = parentSyncZ;
        Cube[1, a].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[0, a].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 225)) * Mathf.Sqrt(2), Mathf.Sin(Mathf.Deg2Rad * (angle + 225)) * Mathf.Sqrt(2), floor - 1);
        Cube[0, a].transform.rotation = parentSyncZ;
        Cube[0, a].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[0, b].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 270)), Mathf.Sin(Mathf.Deg2Rad * (angle + 270)), floor - 1);
        Cube[0, b].transform.rotation = parentSyncZ;
        Cube[0, b].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[0, c].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 315)) * Mathf.Sqrt(2), Mathf.Sin(Mathf.Deg2Rad * (angle + 315)) * Mathf.Sqrt(2), floor - 1);
        Cube[0, c].transform.rotation = parentSyncZ;
        Cube[0, c].transform.Rotate(new Vector3(-angle, 0, 0));

        Cube[1, b].transform.rotation = parentSyncZ;
        Cube[1, b].transform.Rotate(new Vector3(-angle, 0, 0));
    }
}
