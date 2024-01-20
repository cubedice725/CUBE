using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PivotRotation : MonoBehaviour
{
    private List<GameObject> activeSide;
    private Vector3 localForward;
    private Vector3 mouseRef;
    private bool dragging = false;
    private bool autoRotating = false;
    private float sensitivity = 0.4f;
    private float speed = 300f;
    private Vector3 rotation;

    private Quaternion targetQuaternion;
    private ReadCube readCube;
    private CubeState cubeState;

    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
    }

    void Update()
    {
        // Rotate에서 값을 보냄
        if (dragging)
        {
            SpinSide(activeSide);
            if (Input.GetMouseButtonUp(0))
            {
                dragging = false;
                RotateToRightAngle();
            }
        }
        // RotateToRightAngle에서 값을 보냄
        if (autoRotating)
        {
            AutoRotate();
        }
    }

    // 가져온 CubeState의 층이 어디인지 확인한 후 회전
    private void SpinSide(List<GameObject> side)
    {
        rotation = Vector3.zero;
        // Rotate()에서 찍힌 좌표를 시작으로 현재 좌표에 빼줌으로서 천천히 회전을 줌(sensitivity은 속도)
        Vector3 mouseOffest = Input.mousePosition - mouseRef;

        if (side == cubeState.up)
        {
            rotation.y = (mouseOffest.x + mouseOffest.y) * sensitivity * 1;
        }
        if (side == cubeState.down)
        {
            rotation.y = (mouseOffest.x + mouseOffest.y) * sensitivity * -1;
        }
        if (side == cubeState.left)
        {
            rotation.z = (mouseOffest.x + mouseOffest.y) * sensitivity * 1;
        }
        if (side == cubeState.right)
        {
            rotation.z = (mouseOffest.x + mouseOffest.y) * sensitivity * -1;
        }
        if (side == cubeState.front)
        {
            rotation.x = (mouseOffest.x + mouseOffest.y) * sensitivity * -1;
        }
        if (side == cubeState.back)
        {
            rotation.x = (mouseOffest.x + mouseOffest.y) * sensitivity * 1;
        }
        transform.Rotate(rotation, Space.Self);
        mouseRef = Input.mousePosition;

    }

    // 루빅스 큐브의 층이 돌리기 위해 시작이 되는 함수
    public void Rotate(List<GameObject> side)
    {
        activeSide = side;
        mouseRef = Input.mousePosition;
        dragging = true;
        // localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;
    }

    // 루빅스 큐브를 섞을때 층을 돌리기 위해 시작이 되는 함수
    public void StartAutoRotate(List<GameObject> side, float angle){
        cubeState.PickUp(side);
        localForward =  Vector3.zero - side[4].transform.parent.transform.localPosition;
        targetQuaternion = Quaternion.AngleAxis(angle, localForward) * transform.localRotation;
        activeSide = side;
        autoRotating = true;
    }

    // 현재 각을 가장 가까운 직각의 값을 주는 함수
    public void RotateToRightAngle()
    {
        Vector3 vec = transform.localEulerAngles;
        vec.x = Mathf.Round(vec.x / 90) * 90;
        vec.y = Mathf.Round(vec.y / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;

        targetQuaternion.eulerAngles = vec;
        autoRotating = true;
    }

    // 자동으로 층을 돌려주는 함수
    private void AutoRotate()
    {
        dragging = false;
        var step = speed * Time.deltaTime;

        // 중심 큐브를 기준으로 직각이 될때까지 돌아감
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetQuaternion, step);

        // 두 점 사이의 각을 확인인하여 1이하로 떨어면 층을 멈춰 정리하는 단계를 실행
        if (Quaternion.Angle(transform.localRotation, targetQuaternion) == 0)
        {
            transform.localRotation = targetQuaternion;
            cubeState.PutDown(activeSide, transform.parent);
            readCube.ReadState();
            CubeState.autoRotating = false;
            autoRotating = false;
            dragging = false;
        }
    }
}
