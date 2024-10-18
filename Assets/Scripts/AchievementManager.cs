using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AchievementManager : MonoBehaviour
{
    public string achievementName;  // 업적 이름
    public float requiredHeight;     // 요구 높이
    public bool isUnlocked;           // 업적 여부
}
