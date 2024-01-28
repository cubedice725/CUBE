using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFace : MonoBehaviour
{
    private List<GameObject> activeSide;
    private Vector3 mouseRef;
    CubeMovement cubeMovement;
    CubeState cubeState;
    ReadCube readCube;
    CubeMap cubeMap;
    Vector3 rotation;

    int layerMask = 1 << 8;

    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
        cubeMovement = FindObjectOfType<CubeMovement>();
        cubeMap = FindObjectOfType<CubeMap>();
        readCube.ReadState();
    }
    void Update()
    {
        // 마우스 좌클릭이 되는 순간
        if (Input.GetMouseButtonDown(0))
        {
            mouseRef = Input.mousePosition;
            // SpinSide함수에 사용될 처음 들어온 마우스 값
            readCube.ReadState();
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 클릭한 분에 Ray가 작동하여 충돌된 오브젝트를 확인
            if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
            {
                GameObject face = hit.collider.gameObject;
                List<List<GameObject>> cubeSides = new List<List<GameObject>>(){
                    cubeState.up,
                    cubeState.down,
                    cubeState.left,
                    cubeState.right,
                    cubeState.front,
                    cubeState.back
                };

                // cubeState에 있는 리스트들을 확인하여 충돌된 오브젝트가 어느 방향에 있는지 확인
                // (Contains는 요소를 파악하는데 게임 오브젝트는 같은 이름이여도 다른 오브젝트이면 다른것으로 인식함)
                foreach (List<GameObject> cubeSide in cubeSides)
                {
                    if (cubeSide.Contains(face))
                    {
                        activeSide = cubeSide;
                    }
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            SpinSide(activeSide);
        }
    }

    // 마우스 위지를 감지하고 회전을 주는 함수
    private void SpinSide(List<GameObject> side)
    {
        
        rotation = Vector3.zero;
        // 마우스 좌클릭이 되는 순간과 현재 감지되고 있는 값을 뺀 값을 가져옴
        Vector3 mouseOffest = Input.mousePosition - mouseRef;

        if (side == cubeState.up)
        {
            cubeMovement.floor = 1;
            rotation.y = (mouseOffest.x + mouseOffest.y) * 0.4f * -1;
            cubeMovement.StartRotate(side, rotation.y);
        }
        if (side == cubeState.down)
        {
            cubeMovement.floor = -1;
            rotation.y = (mouseOffest.x + mouseOffest.y) * 0.4f * -1;
            cubeMovement.StartRotate(side, rotation.y);
        }
        if (side == cubeState.left)
        {
            cubeMovement.floor = 1;
            rotation.z = (mouseOffest.x + mouseOffest.y) * 0.4f * -1;
            cubeMovement.StartRotate(side, rotation.z);
        }
        if (side == cubeState.right){
            cubeMovement.floor = -1;
            rotation.z = (mouseOffest.x + mouseOffest.y) * 0.4f * -1;
            cubeMovement.StartRotate(side, rotation.z);
        }
        if (side == cubeState.front)
        {
            cubeMovement.floor = -1;
            rotation.x = (mouseOffest.x + mouseOffest.y) * 0.4f * -1;
            cubeMovement.StartRotate(side, rotation.x);
        }
        if (side == cubeState.back)
        {
            cubeMovement.floor = 1;
            rotation.x = (mouseOffest.x + mouseOffest.y) * 0.4f * -1;
            cubeMovement.StartRotate(side, rotation.x);
        }
        mouseRef = Input.mousePosition;
    }
}
