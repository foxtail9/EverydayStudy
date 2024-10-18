using System;
using UnityEngine;

public class EnergySystemC : MonoBehaviour
{
    public float maxEnergy = 30f;   // �ִ� ���ᷮ
    public float currentEnergy = 0f;     // ���� ���ᷮ

    // ���ᰡ ����� �� �߻��ϴ� �̺�Ʈ
    public event Action<float> OnEnergyChanged;

    private void Awake()
    {
        // �ʱ� ���ᷮ ����
        currentEnergy = maxEnergy;
    }
    
    // ���� ��� �޼���
    public void UseEnergy(float amount)
    {
        // ���ᰡ ������� Ȯ�� �� ���
        if (currentEnergy > 0)
        {
            currentEnergy -= amount;
            currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);

            // ���ᰡ ����Ǿ��� �� �̺�Ʈ ȣ��
            OnEnergyChanged?.Invoke(currentEnergy);
        }
    }

    // ���� ���ᷮ ��ȯ �޼���
    public float GetCurrentEnergy()
    {
        return currentEnergy;
    }
}
