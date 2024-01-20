using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//루빅스 큐브의 전체 회전을 애니메이션과 동작을 담당하는 class
public class RotateBigCube : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    Vector3 previousMousePosition;
    Vector3 mouseDelta;

    public GameObject target;
    float speed = 200f;

    void Update()
    {
        if (Automate.moveList.Count <= 0){
            Swipe();
            Drag();
        }
    }

    // Swipe(); Drag();는 우클릭을 통해 작동하는 함수
    // 마우스를 클릭하는 중을 인식하여 큐브를 돌리는 방향을 인식
    // 미리 회전할 부분을 보여주는 역할
    void Drag()
    {
        // 마우스 클릭하기 전의 값을 통해 내가 움직이는 거리를 확인하여 방향을 회전
        if (Input.GetMouseButton(1))
        {
            mouseDelta = Input.mousePosition - previousMousePosition;

            mouseDelta *= 0.1f;
            transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;
        }
        else
        {
            // Swipe함수에서 돌아간 target 루빅스 큐브와 실제 루빅스 큐브각도가 맞지 않을 경우 
            //큐브를 Time.deltaTime을 통해 돌아가는 애니메이션을 보여줌
            if (transform.rotation != target.transform.rotation)
            {
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
            }
        }
        // 마우스 클릭하기 전의 값을 저장
        previousMousePosition = Input.mousePosition;
    }

    // 마우스 클릭한 순간, 마우스를 때는 순간을 기억하여 한번에 루빅스 큐브를 돌림
    void Swipe()
    {
        //마우스 클릭순간을 인식후 기억
        if (Input.GetMouseButtonDown(1))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        //마우스 클릭후 클릭한 순간의 값을 활용하여 큐브를 회전
        if (Input.GetMouseButtonUp(1))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();


            if (LeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 90, 0, Space.World);
            }
            else if (RightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, -90, 0, Space.World);
            }
            else if (UpLeftSwipe(currentSwipe))
            {
                target.transform.Rotate(90, 0, 0, Space.World);
            }
            else if (UpRightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 0, -90, Space.World);
            }
            else if (DownLeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 0, 90, Space.World);
            }
            else if (DownRightSwipe(currentSwipe))
            {
                target.transform.Rotate(-90, 0, 0, Space.World);
            }
        }
    }

    // 벡터의 정규화를 통한 값을 받아 어느 방향으로 회전시킬지 정하는 함수
    bool LeftSwipe(Vector2 swipe)
    {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool RightSwipe(Vector2 swipe)
    {
        return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool UpLeftSwipe(Vector2 swipt)
    {
        return currentSwipe.y > 0 && currentSwipe.x < 0f;
    }
    bool UpRightSwipe(Vector2 swipt)
    {
        return currentSwipe.y > 0 && currentSwipe.x > 0f;
    }
    bool DownLeftSwipe(Vector2 swipt)
    {
        return currentSwipe.y < 0 && currentSwipe.x < 0f;
    }
    bool DownRightSwipe(Vector2 swipt)
    {
        return currentSwipe.y < 0 && currentSwipe.x > 0f;
    }
}
