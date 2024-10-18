using UnityEngine;
using UnityEngine.InputSystem;


public class RocketController : MonoBehaviour
{
    public float moveEnergyCost = 3f;   // �̵� �� �Ҹ�Ǵ� ����
    public float boostEnergyCost = 10f;  // �ν�Ʈ �� �Ҹ�Ǵ� ����
    public float moveSpeed = 5f;
    public float boostMultiplier = 3f;

    private Rigidbody2D rb;
    private EnergySystemC energySystem;
    private EnergyDashboardC energyUI;
    private RocketControls controls;
    private readonly float maxFuel = 30f; // �ִ밪 (�������� ��ü��)
    private float fuel = 0f;            // ���簪 (�������� ���� ����)
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new RocketControls();
        energySystem = GetComponent<EnergySystemC>();
        energyUI = GetComponent<EnergyDashboardC>();

        energySystem.currentEnergy = maxFuel;

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
    private void Update()
    {
        energySystem.currentEnergy = Mathf.Min(energySystem.currentEnergy + 3f * Time.deltaTime, maxFuel);
        energyUI.UpdateEnergyBar(energySystem.currentEnergy);
    }

    private void Move()
    {
        // ���ᰡ ����� ���� �̵�
        if (energySystem.GetCurrentEnergy() > 0)
        {
            Debug.Log("Space �߻�");
            float force = moveSpeed;
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            
            // ���� �Ҹ�
            energySystem.UseEnergy(moveEnergyCost);
        }
        else
        {
            Debug.Log("Space �������");
        }
    }

    private void Boost()
    {
        if (energySystem.GetCurrentEnergy() > 0)
        {
            Debug.Log("Boost �߻�");
            float force = moveSpeed * boostMultiplier;
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            energySystem.UseEnergy(moveEnergyCost * boostMultiplier);
        }
        else
        {
            Debug.Log("Space �������");
        }
    }
}
