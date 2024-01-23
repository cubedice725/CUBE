using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CubeMovement : MonoBehaviour
{
    private List<GameObject> nowCube;
    private float firstAngle;
    private float mamoryAngle = 0;
    int testFloor;
    bool auto = false;
    void Start()
    {
    }

    void Update()
    {
        // 마우스 우측 클릭이 올라가면 자동으로 90도 각도로 맞춰 지도록 함
        if (Input.GetMouseButtonUp(0))
        {
            auto = true;
            mamoryAngle += RotateToRightAngle(firstAngle);
            TotalRotate(nowCube, mamoryAngle);
            auto = false;
        }
    }

    // 90도 각도 맞춰주는 함수
    public float RotateToRightAngle(float inAngle)
    {

        // vec.y = Mathf.Round(angle.y / 90) * 90;
        // vec.z = Mathf.Round(angle.z / 90) * 90;
        return Mathf.Round(inAngle / 90) * 90;
    }

    // 마우스 좌클릭이 되는 순간과 현재 감지되고 있는 값을 뺀 값을 받는중
    public void TotalRotate(List<GameObject> cube, float inAngle)
    {
        float testmodule;
        testFloor = -1;
        nowCube = cube;

        if (auto)
        {
            testmodule = -mamoryAngle;
            inAngle = RotateToRightAngle(firstAngle);
        }
        else
        {
            firstAngle = inAngle;
            testmodule = - inAngle - mamoryAngle;
        }

        var parentSyncX = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        cube[3].transform.parent.localPosition = new Vector3(testFloor, Mathf.Sin(Mathf.Deg2Rad * (inAngle + 0)), Mathf.Cos(Mathf.Deg2Rad * (inAngle + 0)));
        cube[3].transform.parent.rotation = parentSyncX;
        cube[3].transform.parent.Rotate(new Vector3(testmodule, 0, 0));

        cube[0].transform.parent.localPosition = new Vector3(testFloor, Mathf.Sin(Mathf.Deg2Rad * (inAngle + 45)) * Mathf.Sqrt(2), Mathf.Cos(Mathf.Deg2Rad * (inAngle + 45)) * Mathf.Sqrt(2));
        cube[0].transform.parent.rotation = parentSyncX;
        cube[0].transform.parent.Rotate(new Vector3(testmodule, 0, 0));

        cube[1].transform.parent.localPosition = new Vector3(testFloor, Mathf.Sin(Mathf.Deg2Rad * (inAngle + 90)), Mathf.Cos(Mathf.Deg2Rad * (inAngle + 90)));
        cube[1].transform.parent.rotation = parentSyncX;
        cube[1].transform.parent.Rotate(new Vector3(testmodule, 0, 0));

        cube[2].transform.parent.localPosition = new Vector3(testFloor, Mathf.Sin(Mathf.Deg2Rad * (inAngle + 135)) * Mathf.Sqrt(2), Mathf.Cos(Mathf.Deg2Rad * (inAngle + 135)) * Mathf.Sqrt(2));
        cube[2].transform.parent.rotation = parentSyncX;
        cube[2].transform.parent.Rotate(new Vector3(testmodule, 0, 0));

        cube[5].transform.parent.localPosition = new Vector3(testFloor, Mathf.Sin(Mathf.Deg2Rad * (inAngle + 180)), Mathf.Cos(Mathf.Deg2Rad * (inAngle + 180)));
        cube[5].transform.parent.rotation = parentSyncX;
        cube[5].transform.parent.Rotate(new Vector3(testmodule, 0, 0));

        cube[8].transform.parent.localPosition = new Vector3(testFloor, Mathf.Sin(Mathf.Deg2Rad * (inAngle + 225)) * Mathf.Sqrt(2), Mathf.Cos(Mathf.Deg2Rad * (inAngle + 225)) * Mathf.Sqrt(2));
        cube[8].transform.parent.rotation = parentSyncX;
        cube[8].transform.parent.Rotate(new Vector3(testmodule, 0, 0));

        cube[7].transform.parent.localPosition = new Vector3(testFloor, Mathf.Sin(Mathf.Deg2Rad * (inAngle + 270)), Mathf.Cos(Mathf.Deg2Rad * (inAngle + 270)));
        cube[7].transform.parent.rotation = parentSyncX;
        cube[7].transform.parent.Rotate(new Vector3(testmodule, 0, 0));

        cube[6].transform.parent.localPosition = new Vector3(testFloor, Mathf.Sin(Mathf.Deg2Rad * (inAngle + 315)) * Mathf.Sqrt(2), Mathf.Cos(Mathf.Deg2Rad * (inAngle + 315)) * Mathf.Sqrt(2));
        cube[6].transform.parent.rotation = parentSyncX;
        cube[6].transform.parent.Rotate(new Vector3(testmodule, 0, 0));

        cube[4].transform.parent.rotation = parentSyncX;
        cube[4].transform.parent.Rotate(new Vector3(testmodule, 0, 0));
    }
    // public void Y_Rotate(int floor, float angle)
    // {
    //     // 큐브 Y부분       
    //     // [2,3] [2,2] [2,1] 
    //     // [2,4] [2,8] [2,0] 
    //     // [2,5] [2,6] [2,7] 
    //     var parentSyncY = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

    //     for (int i = 0; i < 8; i++)
    //     {
    //         if (i % 2 == 0)
    //         {
    //             Cube[i].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + i * 45)), floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + i * 45)));
    //             Cube[i].transform.rotation = parentSyncY;
    //             Cube[i].transform.Rotate(new Vector3(0, -angle, 0));

    //         }
    //         else
    //         {
    //             Cube[i].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + i * 45)) * Mathf.Sqrt(2), floor - 1, Mathf.Sin(Mathf.Deg2Rad * (angle + i * 45)) * Mathf.Sqrt(2));
    //             Cube[i].transform.rotation = parentSyncY;
    //             Cube[i].transform.Rotate(new Vector3(0, -angle, 0));

    //         }
    //     }
    //     Cube[8].transform.rotation = parentSyncY;
    //     Cube[8].transform.Rotate(new Vector3(0, -angle, 0));
    // }
    // public void X_Rotate(int floor)
    // {


    // }
    // public void Z_Rotate(int floor, float angle)
    // {
    //     // 큐브 Z부분(2) Z=1 | 큐브 Z부분(1) Z=0 | 큐브 Z부분(1) Z=-1
    //     // [2,3] [2,2] [2,1] | [2,4] [2,8] [2,0] | [2,5] [2,6] [2,7]
    //     // [1,3] [1,2] [1,1] | [1,4] [1,8] [1,0] | [1,5] [1,6] [1,7]
    //     // [0,3] [0,2] [0,1] | [0,4] [0,8] [0,0] | [0,5] [0,6] [0,7]
    //     angle += Time.deltaTime * 100;

    //     var parentSyncZ = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    //     Cube[5].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 0)), Mathf.Sin(Mathf.Deg2Rad * (angle + 0)), floor - 1);
    //     Cube[5].transform.rotation = parentSyncZ;
    //     Cube[5].transform.Rotate(new Vector3(-angle, 0, 0));

    //     Cube[2].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 45)) * Mathf.Sqrt(2), Mathf.Sin(Mathf.Deg2Rad * (angle + 45)) * Mathf.Sqrt(2), floor - 1);
    //     Cube[2].transform.rotation = parentSyncZ;
    //     Cube[2].transform.Rotate(new Vector3(-angle, 0, 0));

    //     Cube[1].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 90)), Mathf.Sin(Mathf.Deg2Rad * (angle + 90)), floor - 1);
    //     Cube[1].transform.rotation = parentSyncZ;
    //     Cube[1].transform.Rotate(new Vector3(-angle, 0, 0));

    //     Cube[0].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 135)) * Mathf.Sqrt(2), Mathf.Sin(Mathf.Deg2Rad * (angle + 135)) * Mathf.Sqrt(2), floor - 1);
    //     Cube[0].transform.rotation = parentSyncZ;
    //     Cube[0].transform.Rotate(new Vector3(-angle, 0, 0));

    //     Cube[3].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 180)), Mathf.Sin(Mathf.Deg2Rad * (angle + 180)), floor - 1);
    //     Cube[3].transform.rotation = parentSyncZ;
    //     Cube[3].transform.Rotate(new Vector3(-angle, 0, 0));

    //     Cube[4].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 225)) * Mathf.Sqrt(2), Mathf.Sin(Mathf.Deg2Rad * (angle + 225)) * Mathf.Sqrt(2), floor - 1);
    //     Cube[4].transform.rotation = parentSyncZ;
    //     Cube[4].transform.Rotate(new Vector3(-angle, 0, 0));

    //     Cube[5].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 270)), Mathf.Sin(Mathf.Deg2Rad * (angle + 270)), floor - 1);
    //     Cube[5].transform.rotation = parentSyncZ;
    //     Cube[5].transform.Rotate(new Vector3(-angle, 0, 0));

    //     Cube[6].transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle + 315)) * Mathf.Sqrt(2), Mathf.Sin(Mathf.Deg2Rad * (angle + 315)) * Mathf.Sqrt(2), floor - 1);
    //     Cube[6].transform.rotation = parentSyncZ;
    //     Cube[6].transform.Rotate(new Vector3(-angle, 0, 0));

    //     Cube[4].transform.rotation = parentSyncZ;
    //     Cube[4].transform.Rotate(new Vector3(-angle, 0, 0));
    // }
}
