using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GroupPlayerAction : MonoBehaviour
{
    // Start is called before the first frame update
    public GroupManager manager;
   
    float h=0;
    float v=0;
    Rigidbody2D rigid;
    public float speed=0;
    bool isHorizonMove;
    private Animator anim;
    Vector3 dirVec;
    GameObject scanObject;
    int upValue=0;
    int downValue=0;
    int rightValue=0;
    int leftValue=0;
    bool upDown=false;
    bool upUp=false;
    bool leftDown=false;
    bool leftUp=false;
    bool rightDown=false;
    bool rightUp=false;
    bool downDown=false;
    bool downUp=false;
    void Awake(){
        rigid=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        
    }
    void Update(){
        h=manager.isGroup ? 0 :rightValue+leftValue;
        v=manager.isGroup ? 0 :upValue+downValue;

        bool hDown=manager.isGroup ? false :rightDown||leftDown;
        bool vDown=manager.isGroup ? false :upDown||downDown;
        bool hUp=manager.isGroup ? false :rightUp||leftUp;
        bool vUp=manager.isGroup ? false :upUp||downUp;
        if(hDown)
            isHorizonMove=true;
        else if(vDown)
            isHorizonMove=false;
        else if(hUp||vUp)
            isHorizonMove=h !=0;
        if(anim.GetInteger("hAxisRaw")!=h){
            anim.SetBool("isChange",true);
            anim.SetInteger("hAxisRaw",(int)h);
        }
        else if(anim.GetInteger("vAxisRaw")!=v){
            anim.SetBool("isChange",true);
            anim.SetInteger("vAxisRaw",(int)v);
        }
        else
            anim.SetBool("isChange",false);
        if(vDown && v==1)
            dirVec=Vector3.up;
        else if(vDown && v==-1)
            dirVec=Vector3.down;
        else if(hDown && h==-1)
            dirVec=Vector3.left;
        else if(hDown && h==1)
            dirVec=Vector3.right;
        
        
            
        
        upDown=false;
        upUp=false;
        leftDown=false;
        leftUp=false;
        rightDown=false;
        rightUp=false;
        downDown=false;
        downUp=false;
        
        
    }
    void FixedUpdate() {
        Vector2 moveVec=isHorizonMove?new Vector2(h,0):new Vector2(0,v);
        rigid.velocity=moveVec*speed;

        Debug.DrawRay(rigid.position,dirVec*0.7f,new Color(0,1,0));
        RaycastHit2D rayHit=Physics2D.Raycast(rigid.position,dirVec,0.7f,LayerMask.GetMask("Object"));

        if(rayHit.collider!=null){
            scanObject=rayHit.collider.gameObject;
        }
        else
            scanObject=null;
        
    }
    public void ButtonDown2(string type)
    {
        switch (type)
        {
            case "U":
                upValue=1;
                upDown=true;
                break;
            case "D":
                downDown=true;
                downValue=-1;
                break;
            case "L":
                leftDown=true;
                leftValue=-1;
                break;
            case "R":
                rightDown=true;
                rightValue=1;
                break;
            case "A":
                if(scanObject!=null)
                    manager.GroupAction(scanObject);
                else if(manager.startTalk)
                {
                    manager.StartAction();
                }
                break;
        }
    }
    public void ButtonUp2(string type)
    {
        switch (type)
        {
            case "U":
                upValue=0;
                upUp=true;
                break;
            case "D":
                downValue=0;
                downUp=true;
                break;
            case "L":
                leftValue=0;
                leftUp=true;
                break;
            case "R":
                rightValue=0;
                rightUp=true;
                break;
            case "A":
                break;
        }
    }

}
