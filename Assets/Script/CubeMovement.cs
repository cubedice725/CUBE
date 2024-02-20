using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.TextCore.Text;

public class CubeMovement : MonoBehaviour
{
    private List<GameObject> nowCube;
    private CubeState cubeState;
    public int floor;
    float angle = 0;
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
            StartRotate(nowCube, 0);
            angle = 0;
            auto = false;
        }
    }

    // 마우스 좌클릭이 되는 순간과 현재 감지되고 있는 값을 뺀 값을 받는중
    public void StartRotate(List<GameObject> side, float inAngle)
    {
        float temp = 0;
        nowCube = side;
        if (!auto)
        {
            angle += inAngle;
        }
        else
        {
            temp = -angle + RotateToRightAngle(angle);
            angle = RotateToRightAngle(angle);
        }

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
            }
            
            for (int i = 0; i < 9; i++)
            {
                Debug.DrawRay(-side[8].transform.parent.transform.parent.position, -side[i].transform.parent.transform.parent.right*1000, Color.red, 0.1f);
                side[i].transform.parent.rotation = Quaternion.AngleAxis(inAngle + temp, -side[i].transform.parent.transform.parent.right) * side[i].transform.parent.rotation;
            }
        }
        if (side == cubeState.right|| side == cubeState.left)
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
            }
            for (int i = 0; i < 9; i++)
            {
                Debug.DrawRay(-side[i].transform.parent.transform.parent.position, side[i].transform.parent.transform.parent.forward*1000, Color.red, 0.1f);
                side[i].transform.parent.rotation = Quaternion.AngleAxis(inAngle + temp, -side[i].transform.parent.transform.parent.forward) * side[i].transform.parent.rotation;
            }
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
            }
            for (int i = 0; i < 9; i++)
            {
                Debug.DrawRay(-side[i].transform.parent.transform.parent.position, -side[i].transform.parent.transform.parent.up*1000, Color.red);
                side[i].transform.parent.rotation = Quaternion.AngleAxis(inAngle + temp, -side[i].transform.parent.transform.parent.up) * side[i].transform.parent.rotation;
            }
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