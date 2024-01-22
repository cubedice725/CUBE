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
    Vector3 rotation;

    int layerMask = 1 << 8;

    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
        cubeMovement = FindObjectOfType<CubeMovement>();
    }
    void Update()
    {
        // 마우스 좌클릭이 되는 순간
        if (Input.GetMouseButtonDown(0))
        {
            mouseRef = Input.mousePosition;
            // print("클릭 순간" + mouseRef);
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
        if (Input.GetMouseButton(0)){
            SpinSide(activeSide);
        }
        if (Input.GetMouseButtonUp(0)){
            
        }
    }
    private void SpinSide(List<GameObject> side)
    {
        rotation = Vector3.zero;
        // Rotate()에서 찍힌 좌표를 시작으로 현재 좌표에 빼줌으로서 천천히 회전을 줌(sensitivity은 속도)
        Vector3 mouseOffest = Input.mousePosition - mouseRef;
        // print("클릭 되는 중" + mouseOffest);

        if (side == cubeState.up)
        {
            rotation.y = (mouseOffest.x + mouseOffest.y) * 1;
        }
        if (side == cubeState.down)
        {
            rotation.y = (mouseOffest.x + mouseOffest.y) * -1;
        }
        if (side == cubeState.left)
        {
            rotation.z = (mouseOffest.x + mouseOffest.y) * 1;
        }
        if (side == cubeState.right)
        {
            rotation.z = (mouseOffest.x + mouseOffest.y) * -1;
        }
        if (side == cubeState.front)
        {
            rotation.x = (mouseOffest.x + mouseOffest.y) * -1;
        }
        if (side == cubeState.back)
        {
            rotation.x = (mouseOffest.x + mouseOffest.y) * 1;
        }
        print(side[1]);
        cubeMovement.TotalRotate(side, rotation);
    }
}
