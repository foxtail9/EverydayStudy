using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewQuestData", menuName = "Quest Data")]
public class QuestManager : MonoBehaviour
{
    // �ν����Ϳ��� ����Ʈ�� ������ �� �ִ� ����Ʈ
    [SerializeField]
    private List<MonsterQuestDataSO> Quests = new List<MonsterQuestDataSO>();

    // �̱��� �ν��Ͻ�
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

    // �̱��� �ʱ�ȭ
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }

    // ���� �� ����Ʈ ���� ���
    private void Start()
    {
        PrintQuestInfo();
    }

    // ��� ����Ʈ�� �̸��� �ּ� ���� ���
    private void PrintQuestInfo()
    {
        for (int i = 0; i < Quests.Count; i++)
        {
            MonsterQuestDataSO quest = Quests[i];
            Debug.Log($"Quest {i + 1} - {quest.GetQuestName()} (�ּ� ���� {quest.GetQuestRequiredLevel()})\n {quest.GetQuestDev()}");
        }
    }
}
