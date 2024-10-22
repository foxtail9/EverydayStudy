using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewQuestData", menuName = "Quest Data")]
public class QuestDataSO : ScriptableObject
{
    //Q3.[���� ���� 1]
    public string QuestName;                               // ����Ʈ�� �̸�
    public string QuestDev;                               // ����Ʈ�� ����
    public int QuestRequiredLevel;                         // ����Ʈ�� �ּҷ���
    public int QuestNPC;                                   // ����Ʈ�� �ִ� NPC�� id (int)
    public List<int> QuestPrerequisites = new List<int>(); // ���� ����Ʈ�� id���� ����Ʈ
}
[CreateAssetMenu(fileName = "NewMonsterQuest", menuName = "Monster Quest Data")]
//Q3.[���� ���� 2] - QuestDataSO��� �޴� Class(���� óġ ����Ʈ)
public class MonsterQuestDataSO : QuestDataSO
{
    public int RequesMonster;  //����Ʈ ���� 
    public int RequesNum;      //óġ�ؾ��� ���� ��

    public string GetQuestName()
    {
        return QuestName;
    }

    public string GetQuestDev()
    {
        return QuestDev;
    }

    public int GetQuestRequiredLevel()
    {
        return QuestRequiredLevel;
    }
}
[CreateAssetMenu(fileName = "NewEncounterQuest", menuName = "Encounter Quest Data")]
//Q3.[���� ���� 2] - QuestDataSO��� �޴� Class(NPC�� ��ȭ�ϱ� ����Ʈ)
public class EncounterQuestDataSO : QuestDataSO
{
    public int RequesNPC;  //�������� NPC ����

    public string GetQuestName()
    {
        return QuestName;
    }

    public int GetQuestRequiredLevel()
    {
        return QuestRequiredLevel;
    }

}