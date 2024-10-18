using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Trigger : MonoBehaviour
{
    public AchievementManager achievement;
    public GameObject AchievUI;
    [SerializeField] private Text uiText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("업적체크");
            if (!achievement.isUnlocked)
            {
                UnlockAchievement();
            }
        }
    }

    private void UnlockAchievement()
    {
        achievement.isUnlocked = true; // 업적 달성 표시
        AchievUI.SetActive( true );
        uiText.text = achievement.achievementName;
    }
}
