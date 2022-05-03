using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GroupManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text groupTalking;
    public GroupTalkManager grouptalkmanager;
    public GameObject NPC;
    public GameObject grouptalkPanel;
    public Image Img;
    public int groupIndex=0;
    public bool isGroup=false;
    public bool giveSel=false;
    public void GroupAction(GameObject obj)
    {
        
        NPC=obj;
        NpcData groupnpc=NPC.GetComponent<NpcData>();
        giveSel=groupnpc.isNpc;
        GroupTalking(groupnpc.id,groupnpc.isNpc);

        grouptalkPanel.SetActive(isGroup);

        
    }
    public void GroupTalking(int id, bool isNpc)
    {
        string groupData=grouptalkmanager.GetTalk(id,groupIndex);
        if(groupData==null){
            isGroup=false;
            groupIndex=0;
            return;
        }
        if(isNpc){
            groupTalking.text=groupData.Split(':')[0];
            Img.sprite=grouptalkmanager.GetPort(id,int.Parse(groupData.Split(':')[1]));
            Img.color=new Color(1,1,1,1);
        }
        else{
            Img.color=new Color(1,1,1,0);
        }
        isGroup=true;
        groupIndex++;
    }
}
