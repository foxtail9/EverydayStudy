using UnityEngine;
using UnityEngine.InputSystem;

public class RocketController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boostMultiplier = 2f;
    private bool isBoosting = false;

    private Rigidbody2D rb;
    private RocketControls controls;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new RocketControls();

        // Move �׼ǿ� ���� �̺�Ʈ ���
        controls.Rocket.Move.performed += ctx => Move();

        // Boost �׼ǿ� ���� �̺�Ʈ ���
        controls.Rocket.Boost.performed += ctx => Boost();
    }

    private void OnEnable()
    {
        controls.Rocket.Enable();
    }

    private void OnDisable()
    {
        controls.Rocket.Disable();
    }

    private void Move()
    {
        float force = isBoosting ? moveSpeed * boostMultiplier : moveSpeed;
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        isBoosting = false; // Boost�� ������ �ٽ� �⺻ ���� ��ȯ
    }

    private void Boost()
    {
        isBoosting = true; // Boost ���� ��ȯ
    }
}
