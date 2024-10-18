using UnityEngine;
using UnityEngine.InputSystem;


public class RocketController : MonoBehaviour
{
    public float moveEnergyCost = 3f;   // 이동 시 소모되는 연료
    public float boostEnergyCost = 10f;  // 부스트 시 소모되는 연료
    public float moveSpeed = 5f;
    public float boostMultiplier = 3f;

    private Rigidbody2D rb;
    private EnergySystemC energySystem;
    private EnergyDashboardC energyUI;
    private RocketControls controls;
    private readonly float maxFuel = 30f; // 최대값 (게이지의 전체값)
    private float fuel = 0f;            // 현재값 (게이지의 현재 상태)
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new RocketControls();
        energySystem = GetComponent<EnergySystemC>();
        energyUI = GetComponent<EnergyDashboardC>();

        energySystem.currentEnergy = maxFuel;

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
    private void Update()
    {
        energySystem.currentEnergy = Mathf.Min(energySystem.currentEnergy + 3f * Time.deltaTime, maxFuel);
        energyUI.UpdateEnergyBar(energySystem.currentEnergy);
    }

    private void Move()
    {
        // 연료가 충분할 때만 이동
        if (energySystem.GetCurrentEnergy() > 0)
        {
            Debug.Log("Space 발사");
            float force = moveSpeed;
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            
            // 연료 소모
            energySystem.UseEnergy(moveEnergyCost);
        }
        else
        {
            Debug.Log("Space 연료부족");
        }
    }

    private void Boost()
    {
        if (energySystem.GetCurrentEnergy() > 0)
        {
            Debug.Log("Boost 발사");
            float force = moveSpeed * boostMultiplier;
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            energySystem.UseEnergy(moveEnergyCost * boostMultiplier);
        }
        else
        {
            Debug.Log("Space 연료부족");
        }
    }
}
