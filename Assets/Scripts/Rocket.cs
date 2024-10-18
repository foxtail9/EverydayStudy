using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Drawing;


public class Rocket : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;
    [SerializeField] private RectTransform canvasRectTransform; // 전체 캔버스 크기 (게이지의 전체 크기)
    [SerializeField] private RectTransform gaugeRectTransform;  // 이미지의 RectTransform (연료 게이지)

    private Rigidbody2D _rb2d;
    private readonly float maxFuel = 30f; // 최대값 (게이지의 전체값)
    private float fuel = 0f;            // 현재값 (게이지의 현재 상태)
    private int scoreMaxY = 0;
    private readonly float SPEED = 5f;
    
    void Awake()
    {
        fuel = maxFuel;
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateGauge();
        ScoreUpDate();
        UpdateGauge();
        fuel = Mathf.Min(fuel + 3f * Time.deltaTime, maxFuel);
    }

    public void Shoot() //로켓발사 버튼
    {
        if (fuel > 0)
        {
            Debug.Log("발사");
            fuel -= 3f;
            _rb2d.AddForce(transform.up * SPEED, ForceMode2D.Impulse);
        }
        else
        {
            Debug.Log("연료 부족");
        }
    }
    public void ScoreUpDate() //현점수,최고점수 갱신
    {
        float currentY = transform.position.y;
        if (currentY > scoreMaxY)
        {
            scoreMaxY = Mathf.FloorToInt(currentY); // float 값을 int로 변환
        }
        // 텍스트를 변경하기 위해서는 아래와 같이 합니다.
        currentScoreTxt.text = $"Score: {Mathf.FloorToInt(currentY)} M";
        HighScoreTxt.text = $"High Score: {scoreMaxY} M";
    }
    void UpdateGauge() //로켓연료 UI
    {
        float widthRatio = fuel / maxFuel;
        float newWidth = canvasRectTransform.sizeDelta.x * widthRatio;
        gaugeRectTransform.sizeDelta = new Vector2(newWidth, gaugeRectTransform.sizeDelta.y);
    }

}
