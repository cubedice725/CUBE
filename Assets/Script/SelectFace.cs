using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFace : MonoBehaviour
{
    CubeState cubeState;
    ReadCube readCube;
    int layerMask = 1 << 8;

    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
    }
    void Update()
    {
        // 마우스 좌클릭이 되는 순간
        if (Input.GetMouseButtonDown(0) && !CubeState.autoRotating)
        {
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
                        cubeState.PickUp(cubeSide);
                        cubeSide[4].transform.parent.GetComponent<PivotRotation>().Rotate(cubeSide);
                    }
                }
            }
        }
    }
}
