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

        // Move 액션에 대한 이벤트 등록
        controls.Rocket.Move.performed += ctx => Move();

        // Boost 액션에 대한 이벤트 등록
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
        isBoosting = false; // Boost가 끝나면 다시 기본 모드로 전환
    }

    private void Boost()
    {
        isBoosting = true; // Boost 모드로 전환
    }
}
