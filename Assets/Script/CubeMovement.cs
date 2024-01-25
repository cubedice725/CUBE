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
            mamoryAngle += RotateToRightAngle(firstAngle);
            StartRotate(nowCube, mamoryAngle);
            auto = false;
        }
    }

    // 마우스 좌클릭이 되는 순간과 현재 감지되고 있는 값을 뺀 값을 받는중
    public void StartRotate(List<GameObject> side, float inAngle)
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

    public void CubeRotation(List<GameObject> side, float inAngle, float rotationAngle)
    {
        var parentSync = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        if (side == cubeState.front || side == cubeState.back)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    side[i].transform.parent.localPosition = new Vector3(floor, Sin(inAngle, i), Cos(inAngle, i));
                }
                else
                {
                    side[i].transform.parent.localPosition = new Vector3(floor, SinSqrt(inAngle, i), CosSqrt(inAngle, i));
                }
                side[i].transform.parent.rotation = parentSync;
                side[i].transform.parent.Rotate(new Vector3(rotationAngle, 0, 0));
            }
            side[8].transform.parent.rotation = parentSync;
            side[8].transform.parent.Rotate(new Vector3(rotationAngle, 0, 0));
        }
        if (side == cubeState.right || side == cubeState.left)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    side[i].transform.parent.localPosition = new Vector3(Sin(inAngle, i), Cos(inAngle, i), floor);
                }
                else
                {
                    side[i].transform.parent.localPosition = new Vector3(SinSqrt(inAngle, i), CosSqrt(inAngle, i), floor);
                }
                side[i].transform.parent.rotation = parentSync;
                side[i].transform.parent.Rotate(new Vector3(0, 0, rotationAngle));
            }
            side[8].transform.parent.rotation = parentSync;
            side[8].transform.parent.Rotate(new Vector3(0, 0, rotationAngle));
        }
        if (side == cubeState.up || side == cubeState.down)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    side[i].transform.parent.localPosition = new Vector3(Cos(inAngle, i), floor, Sin(inAngle, i));
                }
                else
                {
                    side[i].transform.parent.localPosition = new Vector3(CosSqrt(inAngle, i), floor, SinSqrt(inAngle, i));
                }
                side[i].transform.parent.rotation = parentSync;
                side[i].transform.parent.Rotate(new Vector3(0, rotationAngle, 0));
            }
            side[8].transform.parent.rotation = parentSync;
            side[8].transform.parent.Rotate(new Vector3(0, rotationAngle, 0));
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
}