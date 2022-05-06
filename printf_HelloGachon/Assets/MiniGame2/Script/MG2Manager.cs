using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MG2Manager : MonoBehaviour
{
    private static MG2Manager _instance;
    public static MG2Manager Instance{
        get{
            if(_instance==null)
            {
                _instance=FindObjectOfType<MG2Manager>();
            }
            return _instance;
        }
    }
    IEnumerator coroutine;
    [SerializeField]
    private GameObject soju;
    [SerializeField]
    private GameObject beer;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject panelbutton;
    [SerializeField]
    private GameObject panelbutton2;
    [SerializeField]
    private GameObject[] listsoju;
    private int num;
    private int playerlife;
    private float GameTime;
    public Text Endtext;
    public bool isWin=false;
    // Start is called before the first frame update
    void Start()
    {
        coroutine=CreateSojuRoutine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        
        StartCoroutine(coroutine);
        panel.SetActive(false);

    }
    public void GameOver()
    {
        playerlife=GameObject.Find("Player").GetComponent<MG2PlayerAction>().life;
        GameTime=GameObject.Find("Timer").GetComponent<Timer>().EndTime;
       if(playerlife==0){
           Debug.Log("패배");
        StopCoroutine(coroutine);
        panel.SetActive(true);
        panelbutton.SetActive(false);
        panelbutton2.SetActive(true);
        Endtext.text="게임 오버";
       }
       if(isWin){
            Debug.Log("승리");
            StopCoroutine(coroutine);
            panel.SetActive(true);
            panelbutton.SetActive(false);
            panelbutton2.SetActive(true);
            Endtext.text="게임 승리";
       }

    }
    IEnumerator CreateSojuRoutine()
    {
        while(true)
        {
            num=Random.Range(0,2);
            CreateSoju(num);
            yield return new WaitForSeconds(1);

        }
        
    }
    
    
    private void CreateSoju(int num)
    {
        
        Vector3 pos=Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f,1.0f),1.1f,0));
        pos.z=0.0f;
        Instantiate(listsoju[num],pos,Quaternion.identity);
    }
    public void NextStory(){
        SceneManager.LoadScene("TopViewGame");
    }
   
}
