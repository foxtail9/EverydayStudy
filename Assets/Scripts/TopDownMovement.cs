using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDwonController movementController;
    private Rigidbody2D movementRigidbody;

    private Vector2 movementDirection = Vector2.zero;


    private void Awake()
    {
        movementController = GetComponent<TopDwonController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // OnMoveEvent�� Move�� ȣ���϶�� �����
        movementController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        Debug.Log("�����̽��� ����");
        // ���� ������Ʈ���� ������ ����
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        // �̵����⸸ ���صΰ� ������ ���������� ����.
        // �����̴� ���� ���� ������Ʈ���� ����(rigidbody�� �����ϱ�)
        movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        //movementRigidbody.AddForce(transform.up * 5f, ForceMode2D.Impulse);
    }
}
