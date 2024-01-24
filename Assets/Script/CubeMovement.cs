using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CubeMovement : MonoBehaviour
{
    private List<GameObject> nowCube;
    private CubeState cubeState;
    private float firstAngle;
    private float mamoryAngle = 0;
    bool auto = false;

    void Start()
    {
        cubeState = FindObjectOfType<CubeState>();
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


    // 마우스 좌클릭이 되는 순간과 현재 감지되고 있는 값을 뺀 값을 받는중
    public void TotalRotate(List<GameObject> side, float inAngle)
    {
        float rotationAngle;
        nowCube = side;

        if (auto)
        {
            rotationAngle = -mamoryAngle;
            inAngle = RotateToRightAngle(firstAngle);
        }
        else
        {
            firstAngle = inAngle;
            rotationAngle = -inAngle - mamoryAngle;
        }
        CubeRotation(side, inAngle, rotationAngle);
        
    }

    public void CubeRotation(List<GameObject> side, float inPAngle, float inRAngle)
    {
        var parentSync = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        int i;
        int floor;
        if (side == cubeState.front)
        {
            floor = -1;
            side[0].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 0), Cos(inPAngle, 0)); //0도
            side[1].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 1), CosSqrt(inPAngle, 1)); //45도
            side[2].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 2), Cos(inPAngle, 2)); //90도
            side[3].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 3), CosSqrt(inPAngle, 3)); //135도
            side[4].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 4), Cos(inPAngle, 4)); //180도
            side[5].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 5), CosSqrt(inPAngle, 5)); //255도
            side[6].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 6), Cos(inPAngle, 6)); //270도
            side[7].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 7), CosSqrt(inPAngle, 7)); //315도
            for (i = 0; i < 9; i++)
            {
                side[i].transform.parent.rotation = parentSync;
                side[i].transform.parent.Rotate(new Vector3(inRAngle, 0, 0));
            }
        }
        if (side == cubeState.back)
        {
            floor = 1;
            side[0].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 1), CosSqrt(inPAngle, 1)); //45도
            side[1].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 2), Cos(inPAngle, 2)); //90도
            side[2].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 3), CosSqrt(inPAngle, 3)); // 135도
            side[3].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 0), Cos(inPAngle, 0)); //0도

            side[5].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 4), Cos(inPAngle, 4)); //180도
            side[6].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 7), CosSqrt(inPAngle, 7)); //315도
            side[7].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 6), Cos(inPAngle, 6)); //270
            side[8].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 5), CosSqrt(inPAngle, 5)); //255도
            for (i = 0; i < 9; i++)
            {
                side[i].transform.parent.rotation = parentSync;
                side[i].transform.parent.Rotate(new Vector3(inRAngle, 0, 0));
            }

        }
        if (side == cubeState.up)
        {
            floor = 1;
            side[0].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 3), CosSqrt(inPAngle, 3)); // 135도
            side[1].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 2), Cos(inPAngle, 2)); //90도
            side[2].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 1), CosSqrt(inPAngle, 1)); //45도
            side[3].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 4), Cos(inPAngle, 4)); //180도

            side[5].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 0), Cos(inPAngle, 0)); //0도
            side[6].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 5), CosSqrt(inPAngle, 5)); //255도
            side[7].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 6), Cos(inPAngle, 6)); //270도
            side[8].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 7), CosSqrt(inPAngle, 7)); //315도
            for (i = 0; i < 9; i++)
            {
                side[i].transform.parent.rotation = parentSync;
                side[i].transform.parent.Rotate(new Vector3(inRAngle, 0, 0));
            }
            // floor = 1;
            // side[0].transform.parent.localPosition = new Vector3(SinSqrt(inPAngle, 1), floor, CosSqrt(inPAngle, 1)); //45도
            // side[1].transform.parent.localPosition = new Vector3(Sin(inPAngle, 2), floor, Cos(inPAngle, 2)); //90도
            // side[2].transform.parent.localPosition = new Vector3(SinSqrt(inPAngle, 3), floor, CosSqrt(inPAngle, 3)); // 135도
            // side[3].transform.parent.localPosition = new Vector3(Sin(inPAngle, 0), floor, Cos(inPAngle, 0)); //0도

            // side[5].transform.parent.localPosition = new Vector3(Sin(inPAngle, 4), floor, Cos(inPAngle, 4)); //180도
            // side[6].transform.parent.localPosition = new Vector3(SinSqrt(inPAngle, 7), floor, CosSqrt(inPAngle, 7)); //315도
            // side[7].transform.parent.localPosition = new Vector3(Sin(inPAngle, 6), floor, Cos(inPAngle, 6)); //270도
            // side[8].transform.parent.localPosition = new Vector3(SinSqrt(inPAngle, 5), floor, CosSqrt(inPAngle, 5)); //255도
            // for (i = 0; i < 9; i++)
            // {
            //     side[i].transform.parent.rotation = parentSync;
            //     side[i].transform.parent.Rotate(new Vector3(0, -inRAngle, 0));
            // }
        }
        if (side == cubeState.down)
        {
            floor = -1;
            side[0].transform.parent.localPosition = new Vector3(SinSqrt(inPAngle, 1), floor, CosSqrt(inPAngle, 1)); //45도
            side[1].transform.parent.localPosition = new Vector3(Sin(inPAngle, 2), floor, Cos(inPAngle, 2)); //90도
            side[2].transform.parent.localPosition = new Vector3(SinSqrt(inPAngle, 3), floor, CosSqrt(inPAngle, 3)); // 135도
            side[3].transform.parent.localPosition = new Vector3(Sin(inPAngle, 0), floor, Cos(inPAngle, 0)); //0도

            side[5].transform.parent.localPosition = new Vector3(Sin(inPAngle, 4), floor, Cos(inPAngle, 4)); //180도
            side[6].transform.parent.localPosition = new Vector3(SinSqrt(inPAngle, 7), floor, CosSqrt(inPAngle, 7)); //315도
            side[7].transform.parent.localPosition = new Vector3(Sin(inPAngle, 6), floor, Cos(inPAngle, 6)); //270도
            side[8].transform.parent.localPosition = new Vector3(SinSqrt(inPAngle, 5), floor, CosSqrt(inPAngle, 5)); //255도
            for (i = 0; i < 9; i++)
            {
                side[i].transform.parent.rotation = parentSync;
                side[i].transform.parent.Rotate(new Vector3(0, -inRAngle, 0));

            }
        }
        if (side == cubeState.left)
        {
            floor = -1;
            side[0].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 1), CosSqrt(inPAngle, 1)); //45도
            side[1].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 2), Cos(inPAngle, 2)); //90도
            side[2].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 3), CosSqrt(inPAngle, 3)); // 135도
            side[3].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 0), Cos(inPAngle, 0)); //0도

            side[5].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 4), Cos(inPAngle, 4)); //180도
            side[6].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 7), CosSqrt(inPAngle, 7)); //315도
            side[7].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 6), Cos(inPAngle, 6)); //270
            side[8].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 5), CosSqrt(inPAngle, 5)); //255도
            for (i = 0; i < 9; i++)
            {
                side[i].transform.parent.rotation = parentSync;
                side[i].transform.parent.Rotate(new Vector3(inRAngle, 0, 0));
            }
        }
        if (side == cubeState.right)
        {
            floor = -1;
            side[0].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 3), CosSqrt(inPAngle, 3)); // 135도
            side[1].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 2), Cos(inPAngle, 2)); //90도
            side[2].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 1), CosSqrt(inPAngle, 1)); //45도
            side[3].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 4), Cos(inPAngle, 4)); //180도

            side[5].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 0), Cos(inPAngle, 0)); //0도
            side[6].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 5), CosSqrt(inPAngle, 5)); //255도
            side[7].transform.parent.localPosition = new Vector3(floor, Sin(inPAngle, 6), Cos(inPAngle, 6)); //270
            side[8].transform.parent.localPosition = new Vector3(floor, SinSqrt(inPAngle, 7), CosSqrt(inPAngle, 7)); //315도
            for (i = 0; i < 9; i++)
            {
                side[i].transform.parent.rotation = parentSync;
                side[i].transform.parent.Rotate(new Vector3(inRAngle, 0, 0));
            }
        }
        else
        {
        }
    }
    public float SinSqrt(float inAngle, int count)
    {
        return Mathf.Sin(Mathf.Deg2Rad * (inAngle + 45 * count)) * Mathf.Sqrt(2);

    }
    public float CosSqrt(float inAngle, int count)
    {
        return Mathf.Cos(Mathf.Deg2Rad * (inAngle + 45 * count)) * Mathf.Sqrt(2);
    }
    public float Sin(float inAngle, int count)
    {
        return Mathf.Sin(Mathf.Deg2Rad * (inAngle + 45 * count));

    }
    public float Cos(float inAngle, int count)
    {
        return Mathf.Cos(Mathf.Deg2Rad * (inAngle + 45 * count));
    }
    public float RotateToRightAngle(float inAngle)
    {
        return Mathf.Round(inAngle / 90) * 90;
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
