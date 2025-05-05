using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {

    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
        if (movementDirection != Vector2.zero)
        {
            lookDirection = movementDirection;
        }
    }

    //void OnLook(InputValue inputValue)
    //{
    //    // 마우스 포인터의 스크린 좌표를 가져옴
    //    Vector2 mousePosition = inputValue.Get<Vector2>();
    //    // 스크린 좌표를 월드 좌표로 변환
    //    Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
    //    // 현재 위치와 마우스 위치 사이의 방향 벡터 계산
    //    lookDirection = (worldPos - (Vector2)transform.position);

    //    // 너무 가까우면 방향을 무시 (회전하지 않도록)
    //    if (lookDirection.magnitude < .9f)
    //    {
    //        lookDirection = Vector2.zero;
    //    }
    //    else
    //    {
    //        // 방향 벡터를 정규화해서 방향만 유지
    //        lookDirection = lookDirection.normalized;
    //    }
    //}

    //void OnFire(InputValue inputValue)
    //{
    //    // UI 요소 위에서 클릭한 경우 공격 무시
    //    if (EventSystem.current.IsPointerOverGameObject())
    //        return;

    //    // 버튼을 누르고 있는지 여부로 공격 상태 설정
    //    isAttacking = inputValue.isPressed;
    //}
}