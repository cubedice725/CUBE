using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automate : MonoBehaviour
{
    
    public static List<string> moveList = new List<string>() { };
    private readonly List<string> allMoves = new List<string>(){
        // 1번 돌림
        "U", "D", "L", "R", "F", "B",
        // 2번 돌림
        "U2", "D2", "L2", "R2", "F2", "B2",
        // 마이너스 방향으로 돌림
        "U'", "D'", "L'", "R'", "F'", "B'"
    };

    private CubeState cubeState;
    private ReadCube readCube;
    void Start()
    {
        cubeState = FindObjectOfType<CubeState>();
        readCube = FindObjectOfType<ReadCube>();
    }

    // 문자열을 받으면 해당되는 움직임을 취함
    void DoMove(string move)
    {
        readCube.ReadState();
        CubeState.autoRotating = true;
        if (move == "U")
        {
            RotateSide(cubeState.up, -90);
        }
        if (move == "U'")
        {
            RotateSide(cubeState.up, 90);
        }
        if (move == "U2")
        {
            RotateSide(cubeState.up, -180);
        }
        if (move == "D")
        {
            RotateSide(cubeState.down, -90);
        }
        if (move == "D'")
        {
            RotateSide(cubeState.down, 90);
        }
        if (move == "D2")
        {
            RotateSide(cubeState.down, -180);
        }
        if (move == "L")
        {
            RotateSide(cubeState.left, -90);
        }
        if (move == "L'")
        {
            RotateSide(cubeState.left, 90);
        }
        if (move == "L2")
        {
            RotateSide(cubeState.left, -180);
        }
        if (move == "R")
        {
            RotateSide(cubeState.right, -90);
        }
        if (move == "R'")
        {
            RotateSide(cubeState.right, 90);
        }
        if (move == "R2")
        {
            RotateSide(cubeState.right, -180);
        }
        if (move == "F")
        {
            RotateSide(cubeState.front, -90);
        }
        if (move == "F'")
        {
            RotateSide(cubeState.front, 90);
        }
        if (move == "F2")
        {
            RotateSide(cubeState.front, -180);
        }
        if (move == "B")
        {
            RotateSide(cubeState.back, -90);
        }
        if (move == "B'")
        {
            RotateSide(cubeState.back, 90);
        }
        if (move == "B2")
        {
            RotateSide(cubeState.back, -180);
        }
    }
    void Update()
    {
        // 움직임에 대한 문자열과 자리를 재배열 하지 않거나 루빅스 큐브의 준비가 끝날때
        if (moveList.Count > 0 && !CubeState.autoRotating && CubeState.started)
        {
            DoMove(moveList[0]);
            moveList.Remove(moveList[0]);
        }
    }

    // 움직임을 주는 문자열을 랜덤으로 넣어줌
    // 버튼UI랑 연결되어 있음
    public void Shuffle(){
        List<string> moves = new List<string>();
        int shuffleLength = Random.Range(10, 30);
        for(int i = 0; i < shuffleLength; i++){
            int randomMove = Random.Range(0, allMoves.Count);
            moves.Add(allMoves[randomMove]);
        }
        moveList = moves;
    }

    // 루빅스 큐브를 돌리기 위해 중심 큐브에 섞어주는 기능이 작동한다는걸 알림
    void RotateSide(List<GameObject> side, float angle)
    {
        PivotRotation pr = side[4].transform.parent.GetComponent<PivotRotation>();
        pr.StartAutoRotate(side, angle);
    }
}
