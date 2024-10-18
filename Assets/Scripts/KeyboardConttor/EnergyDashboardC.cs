using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDashboardC : MonoBehaviour
{
    [SerializeField] private RectTransform canvasRectTransform; // 전체 캔버스 크기 (게이지의 전체 크기)
    [SerializeField] private RectTransform gaugeRectTransform;  // 이미지의 RectTransform (연료 게이지)
    private EnergySystemC energySystem;
    private readonly float maxFuel = 30f; // 최대값 (게이지의 전체값)
    private float fuel = 0f;            // 현재값 (게이지의 현재 상태)
    private void Start()
    {
        // EnergySystemC 컴포넌트 가져오기
        energySystem = FindObjectOfType<EnergySystemC>();

        // EnergySystem에서 연료가 변경될 때마다 OnEnergyChanged 이벤트 구독
        if (energySystem != null)
        {
            energySystem.OnEnergyChanged += UpdateEnergyBar;
        }
    }

    // 연료바를 업데이트하는 메서드
    public void UpdateEnergyBar(float normalizedEnergy)
    {
        float widthRatio = normalizedEnergy / 30f;
        float newWidth = canvasRectTransform.sizeDelta.x * widthRatio;
        gaugeRectTransform.sizeDelta = new Vector2(newWidth, gaugeRectTransform.sizeDelta.y);
    }

    private void OnDestroy()
    {
        // 구독 해제
        if (energySystem != null)
        {
            energySystem.OnEnergyChanged -= UpdateEnergyBar;
        }
    }
}
