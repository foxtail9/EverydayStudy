using System;
using UnityEngine;

public class EnergySystemC : MonoBehaviour
{
    public float maxEnergy = 30f;   // 최대 연료량
    public float currentEnergy = 0f;     // 현재 연료량

    // 연료가 변경될 때 발생하는 이벤트
    public event Action<float> OnEnergyChanged;

    private void Awake()
    {
        // 초기 연료량 설정
        currentEnergy = maxEnergy;
    }
    
    // 연료 사용 메서드
    public void UseEnergy(float amount)
    {
        // 연료가 충분한지 확인 후 사용
        if (currentEnergy > 0)
        {
            currentEnergy -= amount;
            currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);

            // 연료가 변경되었을 때 이벤트 호출
            OnEnergyChanged?.Invoke(currentEnergy);
        }
    }

    // 현재 연료량 반환 메서드
    public float GetCurrentEnergy()
    {
        return currentEnergy;
    }
}
