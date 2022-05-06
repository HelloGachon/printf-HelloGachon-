using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Cinemachine;

public class gameManager : MonoBehaviour
{
    private CinemachineVirtualCamera cmCamera;    
    public TalkManager talkManager;
    public QuestManager questManager;
    public GameObject talkPanel;
    public GameObject talkPanel2;
    public GameObject mudangDown;
    public Text talkText;
    public Text talkText2;
    public GameObject scanObject;
    public bool isAction;
    public bool objectDetect = false; 
    public int talkIndex;
    public Image portraitImg;
    public GameObject cmVcam;   // cm카메라 오브젝트
    private int num=0;
    public GameObject heetalkPanel3; // 무당이 예/ 아니오 판넬
    public GameObject heenewStu; //newStu 오브젝트
    public GameObject heemudang; //mudang 오브젝트
    private Rigidbody2D rb2;
    


  
    void Awake() {
        cmCamera = cmVcam.GetComponent<CinemachineVirtualCamera>();
        rb2 = heemudang.GetComponent<Rigidbody2D>();
        Debug.Log(questManager.CheckQuest());
    }

    void Start(){
        TestSub();
    }


    public void TestSub(){
        string talkData2 = talkManager.GetTalk(7000, talkIndex); //처음에 게임 시작 전에 인트로가 나올 수 있도록 구성

        //End Talk
        if(talkData2 ==null){
            objectDetect = false;
            talkIndex = 0;
            talkPanel.SetActive(false);
            // Debug.Log(questManager.CheckQuest(id));
            return; //void 에서 return 가능(강제 종료 기능)-> return 뒤에 아무것도 안쓰면 됌

        }
        
        talkText.text = talkData2.Split(':')[0];
        portraitImg.sprite = talkManager.GetPortrait(7000,int.Parse(talkData2.Split(':')[1]));
        portraitImg.color = new Color(1,1,1,1); //맨 끝이 투명도로, npc일때만 이미지가 나오도록 설정

        objectDetect = true;

        talkPanel.SetActive(true);
        talkIndex++;
        
    }
    
    // 조사대상이 있을 때만 대화창 띄우기
    public void Action(GameObject scanObj)
    {
       
        scanObject = scanObj;
        ObjectData objData =scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNpc);
        
        talkPanel.SetActive(isAction);
    }

    public void Talk(int id, bool isNpc)
    {
        //Set Talk Data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id+questTalkIndex, talkIndex);

        //End Talk
        if(talkData ==null){
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return; //void 에서 return 가능(강제 종료 기능)-> return 뒤에 아무것도 안쓰면 됌
        }

        if(isNpc){
            talkText.text = talkData.Split(':')[0];
            portraitImg.sprite = talkManager.GetPortrait(id,int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1,1,1,1); //맨 끝이 투명도로, npc일때만 이미지가 나오도록 설정
        }else{
            talkText.text = talkData;
            portraitImg.color = new Color(1,1,1,0);
        }

        isAction = true;
        talkIndex++;
    }
 //마우스 클릭시 퀘스트 마크가 팝업
    public void questionMark1(){
        talkPanel2.SetActive(true);
        talkText2.text = "무당이를 타면 더 빨리 이동할 수 있습니다. 탑승 후 내리고 싶을 때 상단 초록색 버튼을 클릭하면 됩니다.";
       
    }
 //마우스 클릭 후 떼어낼때 퀘스트 마크가 팝다운
    public void questionMark2(){
        talkPanel2.SetActive(false);
       
       
    }
//마우스 클릭시 무당이를 내림
    public void noneMudang(){
        var mudangAction = heemudang.GetComponent<MudangAction>();
        Vector3 pos2;
        pos2 = this.heemudang.transform.position;
        mudangDown.SetActive(false);
        heetalkPanel3.SetActive(false);

        heenewStu.SetActive(true);
        SetCameraTarget(heenewStu);

        mudangAction.enabled = false;

        rb2.constraints = RigidbodyConstraints2D.FreezeAll;
        heenewStu.transform.position = new Vector3(pos2.x+3,pos2.y+3, 0);
    }


    public void SetCameraTarget(GameObject followTarget)
    {
        if(cmCamera == null)
        {
            Debug.Log("cmCamera is null");                        
        }

        if(followTarget == null) Debug.Log("followTarget is null");
        cmCamera.Follow = followTarget.transform;
        cmCamera.LookAt = followTarget.transform;        
    }    

}
