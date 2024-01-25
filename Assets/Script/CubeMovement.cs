using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CubeMovement : MonoBehaviour
{
    private List<GameObject> nowCube;
    private CubeState cubeState;
    private float firstAngle;
    private float mamoryAngle;
    private float frontAngle;
    private float backAngle;
    private float upAngle;
    private float downAngle;
    private float rigntAngle;
    private float leftAngle;
    float angle = 0;
    public int floor;
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
            angle = RotateToRightAngle(angle);
            StartRotate(nowCube, angle);
            angle = 0;
            auto = false;

        }
    }

    // 마우스 좌클릭이 되는 순간과 현재 감지되고 있는 값을 뺀 값을 받는중
    public void StartRotate(List<GameObject> side, float inAngle)
    {
        nowCube = side;
        CubeRotation(side, inAngle);
    }

    public void CubeRotation(List<GameObject> side, float inAngle)
    {
        print(inAngle);
        if(!auto){
            if( angle >= 360){
                angle += inAngle;
            }
        }
        var parentSync = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        print(angle);
        if (side == cubeState.front || side == cubeState.back)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    side[i].transform.parent.localPosition = new Vector3(floor, Sin(angle, i), Cos(angle, i));
                }
                else
                {
                    side[i].transform.parent.localPosition = new Vector3(floor, SinSqrt(angle, i), CosSqrt(angle, i));
                }
                if (auto)
                {
                    side[i].transform.parent.rotation = parentSync;
                }
                side[i].transform.parent.Rotate(new Vector3(-inAngle, 0, 0));

            }
            if (auto)
            {
                side[8].transform.parent.rotation = parentSync;
            }
            side[8].transform.parent.Rotate(new Vector3(-inAngle, 0, 0));
        }
        if (side == cubeState.right || side == cubeState.left)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    side[i].transform.parent.localPosition = new Vector3(Sin(angle, i), Cos(angle, i), floor);
                }
                else
                {
                    side[i].transform.parent.localPosition = new Vector3(SinSqrt(angle, i), CosSqrt(angle, i), floor);
                }
                side[i].transform.parent.Rotate(new Vector3(0, 0, -inAngle));
            }
            side[8].transform.parent.Rotate(new Vector3(0, 0, -inAngle));
        }
        if (side == cubeState.up || side == cubeState.down)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    side[i].transform.parent.localPosition = new Vector3(Cos(angle, i), floor, Sin(angle, i));
                }
                else
                {
                    side[i].transform.parent.localPosition = new Vector3(CosSqrt(angle, i), floor, SinSqrt(angle, i));
                }
                side[i].transform.parent.Rotate(new Vector3(0, -inAngle, 0));
            }
            side[8].transform.parent.Rotate(new Vector3(0, -inAngle, 0));
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
    public float Angle360(float inAngle){
        return inAngle -= 360;
    }
}