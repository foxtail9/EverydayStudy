using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDashboardC : MonoBehaviour
{
    [SerializeField] private RectTransform canvasRectTransform; // ��ü ĵ���� ũ�� (�������� ��ü ũ��)
    [SerializeField] private RectTransform gaugeRectTransform;  // �̹����� RectTransform (���� ������)
    private EnergySystemC energySystem;
    private readonly float maxFuel = 30f; // �ִ밪 (�������� ��ü��)
    private float fuel = 0f;            // ���簪 (�������� ���� ����)
    private void Start()
    {
        // EnergySystemC ������Ʈ ��������
        energySystem = FindObjectOfType<EnergySystemC>();

        // EnergySystem���� ���ᰡ ����� ������ OnEnergyChanged �̺�Ʈ ����
        if (energySystem != null)
        {
            energySystem.OnEnergyChanged += UpdateEnergyBar;
        }
    }

    // ����ٸ� ������Ʈ�ϴ� �޼���
    public void UpdateEnergyBar(float normalizedEnergy)
    {
        float widthRatio = normalizedEnergy / 30f;
        float newWidth = canvasRectTransform.sizeDelta.x * widthRatio;
        gaugeRectTransform.sizeDelta = new Vector2(newWidth, gaugeRectTransform.sizeDelta.y);
    }

    private void OnDestroy()
    {
        // ���� ����
        if (energySystem != null)
        {
            energySystem.OnEnergyChanged -= UpdateEnergyBar;
        }
    }
}
