using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TopViewManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text talking;
    public TalkManager talkmanager;
    public GameObject Npc;
    public GameObject talkingPanel;
    public bool isTalk;
    public int talkIndex;
    public int selid;
    public bool isSel;
   
    public void TalkingAction(GameObject obj)
    {
        Npc=obj;
        NpcData npcData=Npc.GetComponent<NpcData>();
        selid=npcData.id;
        isSel=npcData.isNpc;
        Talk(npcData.id,npcData.isNpc); 

         talkingPanel.SetActive(isTalk);
    }

    public void Talk(int id,bool isNpc)
    {
        string talkData=talkmanager.GetTalk(id, talkIndex);
        
        if(talkData==null){
            isTalk=false;
            talkIndex=0;
            return;
        }
        if(isNpc){
            talking.text=talkData;
        }
        isTalk=true;
        talkIndex++;
      
    }
}
