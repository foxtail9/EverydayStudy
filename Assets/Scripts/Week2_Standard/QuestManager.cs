using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewQuestData", menuName = "Quest Data")]
public class QuestManager : MonoBehaviour
{
    // 인스펙터에서 퀘스트를 설정할 수 있는 리스트
    [SerializeField]
    private List<MonsterQuestDataSO> Quests = new List<MonsterQuestDataSO>();

    // 싱글톤 인스턴스
    private static QuestManager _instance;

    public static QuestManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new QuestManager();
            }
            return _instance;
        }
    }

    // 싱글톤 초기화
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    // 시작 시 퀘스트 정보 출력
    private void Start()
    {
        PrintQuestInfo();
    }

    // 모든 퀘스트의 이름과 최소 레벨 출력
    private void PrintQuestInfo()
    {
        for (int i = 0; i < Quests.Count; i++)
        {
            MonsterQuestDataSO quest = Quests[i];
            Debug.Log($"Quest {i + 1} - {quest.GetQuestName()} (최소 레벨 {quest.GetQuestRequiredLevel()})\n {quest.GetQuestDev()}");
        }
    }
}
