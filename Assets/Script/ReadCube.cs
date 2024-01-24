using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;

// 루빅스 큐브의 위치를 파악하는 class
public class ReadCube : MonoBehaviour
{
    // Ray의 위치를 할당 받을 변수
    public Transform tUp;
    public Transform tDown;
    public Transform tLeft;
    public Transform tRight;
    public Transform tFront;
    public Transform tBack;

    // 복제된 Ray를 저장할 변수
    private List<GameObject> frontRays = new List<GameObject>();
    private List<GameObject> backRays = new List<GameObject>();
    private List<GameObject> upRays = new List<GameObject>();
    private List<GameObject> downRays = new List<GameObject>();
    private List<GameObject> leftRays = new List<GameObject>();
    private List<GameObject> rightRays = new List<GameObject>();

    private int layerMask = 1 << 8;
    CubeState cubeState;
    CubeMap cubeMap;
    public GameObject emptyGo;
    int[,] XY = { { -1, 0 }, { -1, 1 }, { 0, 1 }, { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 }, { 0, 0 } };
    void Start()
    {
        SetRayTransforms();
        cubeState = FindObjectOfType<CubeState>();
        cubeMap = FindObjectOfType<CubeMap>();
        ReadState();
        CubeState.started = true;

    }
    void Update()
    {
        ReadState();

    }

    // 업데이트 된 위치에서 인식하여 색상을 읽어오는 함수
    public void ReadState()
    {
        cubeState = FindObjectOfType<CubeState>();
        cubeMap = FindObjectOfType<CubeMap>();

        cubeState.up = ReadFace(upRays, tUp);
        cubeState.down = ReadFace(downRays, tDown);
        cubeState.left = ReadFace(leftRays, tLeft);
        cubeState.right = ReadFace(rightRays, tRight);
        cubeState.front = ReadFace(frontRays, tFront);
        cubeState.back = ReadFace(backRays, tBack);

        cubeMap.Set();
    }

    // Ray의 방향과 위치를 확인하여 BuildRays통해 복제하는 함수
    void SetRayTransforms()
    {
        upRays = BuildRays(tUp, new Vector3(90, 90, 0));
        downRays = BuildRays(tDown, new Vector3(270, 90, 0));
        leftRays = BuildRays(tLeft, new Vector3(0, 180, 0));
        rightRays = BuildRays(tRight, new Vector3(0, 0, 0));
        frontRays = BuildRays(tFront, new Vector3(0, 90, 0));
        backRays = BuildRays(tBack, new Vector3(0, 270, 0));
    }

    //Ray를 복제하는 함수
    List<GameObject> BuildRays(Transform rayTransform, Vector3 direction)
    {
        int rayCount = 0;
        List<GameObject> rays = new List<GameObject>();
        // -1, 1 | 0, 1 | 1, 1
        // -1, 0 | 0, 0 | 1, 0
        // -1,-1 | 0,-1 | 1,-1
        // 위의 방식으로 큐브를 생성한 후
        for (int i = 0; i < 9; i++)
        {
            Vector3 startPos = new Vector3(rayTransform.localPosition.x + XY[i,0], rayTransform.localPosition.y + XY[i,1], rayTransform.localPosition.z);
            GameObject rayStart = Instantiate(emptyGo, startPos, Quaternion.identity, rayTransform);
            rayStart.name = rayCount.ToString();
            rays.Add(rayStart);
            rayCount++;
        }
        // 수직으로 생성된 Ray을 돌림
        rayTransform.localRotation = Quaternion.Euler(direction);
        return rays;
    }

    // Ray를 통해 색상을 읽어 내는 함수
    public List<GameObject> ReadFace(List<GameObject> rayStarts, Transform rayTransform)
    {
        List<GameObject> facesHit = new List<GameObject>();

        // Ray가 위치한 앞부분에 색상값(타일)을 인식하는 역할
        foreach (GameObject reyStart in rayStarts)
        {
            Vector3 ray = reyStart.transform.position;
            RaycastHit hit;

            // Ray를 통해 facesHit에 색상을 넣어줌
            if (Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);
                facesHit.Add(hit.collider.gameObject);
            }
            else
            {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }
        return facesHit;
    }
}
