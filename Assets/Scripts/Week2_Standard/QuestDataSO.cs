using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewQuestData", menuName = "Quest Data")]
public class QuestDataSO : ScriptableObject
{
    //Q3.[구현 사항 1]
    public string QuestName;                               // 퀘스트의 이름
    public string QuestDev;                               // 퀘스트의 내용
    public int QuestRequiredLevel;                         // 퀘스트의 최소레벨
    public int QuestNPC;                                   // 퀘스트를 주는 NPC의 id (int)
    public List<int> QuestPrerequisites = new List<int>(); // 선행 퀘스트의 id들의 리스트
}
[CreateAssetMenu(fileName = "NewMonsterQuest", menuName = "Monster Quest Data")]
//Q3.[구현 사항 2] - QuestDataSO상속 받는 Class(몬스터 처치 퀘스트)
public class MonsterQuestDataSO : QuestDataSO
{
    public int RequesMonster;  //퀘스트 몬스터 
    public int RequesNum;      //처치해야할 몬스터 수

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
//Q3.[구현 사항 2] - QuestDataSO상속 받는 Class(NPC와 대화하기 퀘스트)
public class EncounterQuestDataSO : QuestDataSO
{
    public int RequesNPC;  //만나야할 NPC 정보

    public string GetQuestName()
    {
        return QuestName;
    }

    public int GetQuestRequiredLevel()
    {
        return QuestRequiredLevel;
    }

}