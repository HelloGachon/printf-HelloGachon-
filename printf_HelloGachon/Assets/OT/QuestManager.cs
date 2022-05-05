using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    Dictionary<int, QuestData> questList;
    public int questId;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        generateData();
    }
    
    void generateData()
    {
        questList.Add(10, new QuestData("신입생 오리엔테이션!", new int[] {1000}));
    }

    public int getQuestTalkIndex(int id)
    {
        return questId;
    }
}
