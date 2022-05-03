using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<int,string[]> talkData;
    string[] data1={"지금 프리덤 광장에서 동아리 홍보를 하고 있어.","보러갈래?"};
    string[] data2={"프리덤 광장으로 가자."};
    string[] data3={"아쉽지만 어쩔 수 없지."};
    string[] data4={"굉장히 많은 동아리가 있는 걸?","어떤 동아리가 있는지 한번 볼까?"};
    string[] MTGO={"왔구나. 오늘 굉장히 기대가 되는걸?","재밌게 놀아보자. 술은 적당히 마실 만큼만 마시는 거야. 알았지?","그럼 재밌게 놀아보자!"};
    public GameObject Select;
    public bool isEnd=false;
    public TopViewManager topviewmanager;
    public int selectid=0;
    public bool selectnpc=false;
    public GameObject Pan;
    void Awake(){
        talkData=new Dictionary<int,string[]>();
        
        StartTalking(1000,data1);
        StartTalking(100,MTGO);
       
        
    }
    public void StartTalking(int id,string[] data)
    {
        talkData.Add(id,data);
        //topviewmanager.Talk(1000,true);
        //Pan.SetActive(true);  
    }
  
    public void SelectTalk(string type)
    {
        selectid=topviewmanager.selid;
        selectnpc=topviewmanager.isSel;
        switch(type)
        {
            case "Y":
            if(selectid==1000)
            {
                isEnd=true;
                Select.SetActive(false);
                talkData[selectid]=data2;
                topviewmanager.Talk(selectid,selectnpc);
                Pan.SetActive(true);
            }
            break;
            case "N":
            if(selectid==1000)
            {
                isEnd=true;
                Select.SetActive(false);
                talkData[selectid]=data3;
                topviewmanager.Talk(selectid,selectnpc);
                Pan.SetActive(true);
            }
            break;
        }

    }
    public string GetTalk(int id,int talkIndex)
    {
        if(id==1000){  
            if(talkIndex==talkData[id].Length){
                if(!isEnd){
                    Select.SetActive(true);
                }
                return null;
            }
            else
                return talkData[id][talkIndex];
        }
        if(id==100)
        {
            if(talkIndex==talkData[id].Length){
                GameObject.Find("Canvas").GetComponent<FadeINOUT>().MTstartFadeOut();
                return null;
            }
            else
                return talkData[id][talkIndex];
        }
          
            if(talkIndex==talkData[id].Length){
                return null;
            }
            else
                return talkData[id][talkIndex];
        

    }
}
