using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex; //퀘스트 순서 정하기
    public GameObject[] questObject; 
    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    // 퀘스트 생성
    void GenerateData()
    {
        questList.Add(10, new QuestData("npc들과 대화하기.", new int[]{1000, 2000}));
        questList.Add(20, new QuestData("오리엔테이션 하러가기", new int[]{2000, 5000, 500}));
        questList.Add(30, new QuestData("오리엔테이션 끝나고 뒷풀이 참석하기", new int[]{2000, 1000}));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        
        //다음 npc 확인
        if(id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        //Control Quest Object
        ControlObject(); 

        //다음 퀘스트 확인
        if(questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }
        //현재 퀘스트의 이름까지 같이 확인
        return questList[questId].questName;
    }

    public string CheckQuest()
    {       
        //현재 퀘스트의 이름까지 같이 확인
        return questList[questId].questName;
    }

    //다음 퀘스트로 넘어가기
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    //퀘스트에서 사용하는 오브젝트 관리!!
    void ControlObject()
    {
        switch (questId)
        {
            case 10: 
                if(questActionIndex ==1 ){
                    questObject[0].SetActive(true);
                }else if(questActionIndex ==2){
                    questObject[0].SetActive(false);
                }
                                   
                break;
            case 20:
                if(questActionIndex ==1)
                    questObject[0].SetActive(false);
                break;

        }
    }
}
