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
    //    // ���콺 �������� ��ũ�� ��ǥ�� ������
    //    Vector2 mousePosition = inputValue.Get<Vector2>();
    //    // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ
    //    Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
    //    // ���� ��ġ�� ���콺 ��ġ ������ ���� ���� ���
    //    lookDirection = (worldPos - (Vector2)transform.position);

    //    // �ʹ� ������ ������ ���� (ȸ������ �ʵ���)
    //    if (lookDirection.magnitude < .9f)
    //    {
    //        lookDirection = Vector2.zero;
    //    }
    //    else
    //    {
    //        // ���� ���͸� ����ȭ�ؼ� ���⸸ ����
    //        lookDirection = lookDirection.normalized;
    //    }
    //}

    //void OnFire(InputValue inputValue)
    //{
    //    // UI ��� ������ Ŭ���� ��� ���� ����
    //    if (EventSystem.current.IsPointerOverGameObject())
    //        return;

    //    // ��ư�� ������ �ִ��� ���η� ���� ���� ����
    //    isAttacking = inputValue.isPressed;
    //}
}